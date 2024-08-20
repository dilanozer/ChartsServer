using System;
namespace ChartsServer.Subscription.Middleware
{
	public static class DatabaseSubscriptionMiddleware
	{
		public static void UseDatabaseSubscription<T>(this IApplicationBuilder builder, string tableName) where T: class, IDatabaseSubscription
		{
			var subscription = (T)builder.ApplicationServices.GetService(typeof(T));
			subscription.Configure(tableName);
		}
	}
}

