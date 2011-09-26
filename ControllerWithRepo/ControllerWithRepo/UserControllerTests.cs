using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using Should.Fluent;

namespace ControllerWithRepo
{
    [TestFixture]
    public class UserControllerTests
    {
        private IUserRepository repository;
        private UserController controller;
        private const int FAKE_USER_ID = 123;
        private const string FAKE_USER_NAME = "Marcus";

        [SetUp]
        public void SetUp()
        {
            repository = Substitute.For<IUserRepository>();
            controller = new UserController(repository);
        }

        [Test]
        public void get_to_Index_returns_a_view_with_all_Users_in_repository()
        {
            // Arrange
            repository.All().Returns(new List<User>
                {
                    new User(),
                    new User(),
                    new User()
                });

            // Act
            var view = controller.Index() as ViewResult;

            // Assert
            (view.Model as IList<User>).Count.Should().Equal(3);
        }

        [Test]
        public void get_to_Detail_should_display_1_User_based_on_sent_in_id()
        {
            // Arrange
            repository.GetUser(FAKE_USER_ID).Returns(new User { Id = FAKE_USER_ID });

            // Act
            var view = controller.Detail(FAKE_USER_ID) as ViewResult;

            // Assert
            (view.Model as User).Id.Should().Equal(FAKE_USER_ID);
        }

        [Test]
        public void get_to_Create_should_return_a_view_for_creating_users()
        {
            // Arrange 
            repository.GetNewUser().Returns(new User { Id = 234 });

            // Act
            var view = controller.Create() as ViewResult;

            // Assert
            (view.Model as User).Id.Should().Equal(234);
        }

        // Example of Get-Post-Redirect http://en.wikipedia.org/wiki/Post/Redirect/Get
        [Test]
        public void post_to_Create_creates_new_user()
        {
            // Arrange
            var user = new User { Name = FAKE_USER_NAME };
            repository.Save(user).Returns(FAKE_USER_ID);

            // Act
            var result = controller.Create(user) as RedirectToRouteResult;

            //// Assert
            result.RouteValues.Count.Should().Equal(2);
            result.RouteValues["action"].Should().Equal("Detail");
            result.RouteValues["Id"].Should().Equal(FAKE_USER_ID);
        }

        [Test]
        public void post_to_Create_with_model_error_returns_to_Create()
        {
            // Arrange
            var user = new User { Id = FAKE_USER_ID, Name = FAKE_USER_NAME };
            controller.ModelState.AddModelError("An error", "The message");

            // Act
            var result = controller.Create(user) as ViewResult;

            // Assert
            (result.Model as User).Id.Should().Equal(FAKE_USER_ID);
            (result.Model as User).Name.Should().Equal(FAKE_USER_NAME);

        }

        [Test]
        public void post_to_Delete_removes_an_user()
        {
            // Arrange
            var user = new User { Id = FAKE_USER_ID, Name = "marcus" };
            repository.Delete(user);

            // Act
            var result = controller.Delete(user) as RedirectToRouteResult;

            // Assert
            result.RouteValues.Count.Should().Equal(1);
            result.RouteValues["action"].Should().Equal("Index");
        }

        [Test]
        public void get_to_Update_action_returns_a_view_with_the_User()
        {
            // Arrange
            repository.GetUser(FAKE_USER_ID).Returns(new User { Id = FAKE_USER_ID, Name = FAKE_USER_NAME });

            // Act
            var view = controller.Update(FAKE_USER_ID) as ViewResult;

            // Assert
            (view.Model as User).Id.Should().Equal(FAKE_USER_ID);
            (view.Model as User).Name.Should().Equal(FAKE_USER_NAME);
        }

        [Test]
        public void post_to_Update_updates_the_user_and_then_redirects_to_Index()
        {
            // Arrange
            var user = new User { Id = FAKE_USER_ID, Name = FAKE_USER_NAME };
            repository.Save(user).Returns(FAKE_USER_ID);

            // Act
            var result = controller.Update(user) as RedirectToRouteResult;

            // Assert
            result.RouteValues.Count.Should().Equal(2);
            result.RouteValues["Id"].Should().Equal(FAKE_USER_ID);
            result.RouteValues["action"].Should().Equal("Detail");
        }

        [Test]
        public void post_to_Update_with_model_error_returns_to_Update_view()
        {
            // Arrange
            controller.ModelState.AddModelError("An error", "A message");
            var user = new User {Id = FAKE_USER_ID, Name = FAKE_USER_NAME};

            // Act
            var result = controller.Update(user) as ViewResult;

            // Assert
            (result.Model as User).Id.Should().Equal(FAKE_USER_ID);
            (result.Model as User).Name.Should().Equal(FAKE_USER_NAME);
        }
    }

    public interface IUserRepository
    {
        IEnumerable<User> All();
        User GetUser(int id);
        User GetNewUser();
        int Save(User user);
        void Delete(User user);
    }

    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var userList = _userRepository.All();
            return View(userList);
        }

        public ActionResult Detail(int id)
        {
            var user = _userRepository.GetUser(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = _userRepository.GetNewUser();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var id = _userRepository.Save(user);
            return RedirectToAction("Detail", new { Id = id });
        }

        public ActionResult Delete(User user)
        {
            _userRepository.Delete(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int userId)
        {
            var user = _userRepository.GetUser(userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var id = _userRepository.Save(user);
            return RedirectToAction("Detail", new {Id = id});
        }
    }
}
