using System;
using NUnit.Framework;
using Should.Fluent;

namespace TriangleKata
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void a_triangle_has_3_sides()
        {
            // Act
            var t = new Triangle(1, 1, 1);

            // Assert
            t.SidesCount.Should().Equal(3);
        }

        [Test]
        public void Circumference_is_equal_to_the_sum_of_the_sides()
        {
            // Arrange
            var t = new Triangle(2, 3, 4);

            // Act
            var omkrets = t.Circumference;

            // Assert
            omkrets.Should().Equal(2 + 3 + 4);
        }

        [Test]
        public void valid_triangle_has_no_side_equal_to_0()
        {
            // Arrange
            var t = new Triangle(0, 2, 3);

            // Act
            var isValid = t.IsValid;

            // Assert
            isValid.Should().Equal(false);
        }

        [Test]
        public void valid_triangle_has_2_side_sum_equal_to_third_site()
        {
            // Arrange
            var t = new Triangle(1, 2, 3);

            // Act
            var isValid = t.IsValid;

            // Assert
            isValid.Should().Equal(true);
        }

        [Test]
        public void a_triangle_with_sides_2_6_9_is_not_a_valid_triangle()
        {
            // Arrange
            var t = new Triangle(2, 6, 9);

            // Act
            var isValid = t.IsValid;

            // Assert
            isValid.Should().Equal(false);
        }
    }
}
