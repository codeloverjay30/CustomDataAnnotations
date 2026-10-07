using CustomDataAnnotations.Validation;
using FluentAssertions;

namespace CustomDataAnnotations.Tests.Validation;

public sealed class PositiveTimeSpanAttributeTests
{
    [Fact]
    public void IsValid_ShouldReturnTrue_WhenValueIsNull()
    {
        // Arrange
        PositiveTimeSpanAttribute sut = new();

        // Act
        bool result = sut.IsValid(null);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(1L)]
    [InlineData(10L)]
    [InlineData(long.MaxValue)]
    public void IsValid_ShouldReturnTrue_WhenTimeSpanIsPositive(
        long ticks)
    {
        // Arrange
        PositiveTimeSpanAttribute sut = new();
        TimeSpan value = TimeSpan.FromTicks(ticks);

        // Act
        bool result = sut.IsValid(value);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsValid_ShouldReturnFalse_WhenTimeSpanIsZero()
    {
        // Arrange
        PositiveTimeSpanAttribute sut = new();

        // Act
        bool result = sut.IsValid(TimeSpan.Zero);

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(-1L)]
    [InlineData(-10L)]
    [InlineData(long.MinValue)]
    public void IsValid_ShouldReturnFalse_WhenTimeSpanIsNegative(
        long ticks)
    {
        // Arrange
        PositiveTimeSpanAttribute sut = new();
        TimeSpan value = TimeSpan.FromTicks(ticks);

        // Act
        bool result = sut.IsValid(value);

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1L)]
    [InlineData(1.0)]
    [InlineData("00:00:01")]
    [InlineData(true)]
    public void IsValid_ShouldReturnFalse_WhenValueIsNotTimeSpan(
        object value)
    {
        // Arrange
        PositiveTimeSpanAttribute sut = new();

        // Act
        bool result = sut.IsValid(value);

        // Assert
        result.Should().BeFalse();
    }
}