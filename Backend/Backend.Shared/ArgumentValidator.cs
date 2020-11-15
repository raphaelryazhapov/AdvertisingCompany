using System;

namespace Backend.Shared
{
	public static class ArgumentValidator
	{
		public static void ValidateGuidNotEmpty(Guid valueToValidate, string exceptionMessage)
		{
			if (valueToValidate == Guid.Empty)
			{
				throw new ArgumentException(exceptionMessage);
			}
		}

		public static void ValidateObjectNotNull(object valueToValidate, string exceptionMessage)
		{
			if (valueToValidate == null)
			{
				throw new ArgumentNullException(exceptionMessage);
			}
		}
	}
}
