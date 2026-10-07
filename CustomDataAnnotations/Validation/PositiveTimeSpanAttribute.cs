using System;
using System.ComponentModel.DataAnnotations;

namespace CustomDataAnnotations.Validation
{
    /// <summary>
    /// Validates that a <see cref="TimeSpan"/> value is greater than
    /// <see cref="TimeSpan.Zero"/>.
    /// </summary>
    /// <remarks>
    /// A <see langword="null"/> value is considered valid. Use
    /// <see cref="RequiredAttribute"/> when null values must be rejected.
    /// </remarks>
    [AttributeUsage(
        AttributeTargets.Property |
        AttributeTargets.Field |
        AttributeTargets.Parameter,
        AllowMultiple = false)]
    public sealed class PositiveTimeSpanAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines whether the specified value is a positive
        /// <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>
        /// <see langword="true"/> when <paramref name="value"/> is
        /// <see langword="null"/> or a <see cref="TimeSpan"/> greater than zero;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (!(value is TimeSpan))
            {
                return false;
            }

            return (TimeSpan)value > TimeSpan.Zero;
        }
    }
}