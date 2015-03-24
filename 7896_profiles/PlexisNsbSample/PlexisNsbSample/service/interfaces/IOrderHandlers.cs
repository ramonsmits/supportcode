﻿using NServiceBus;
using NServiceBus.Unicast.Config;

namespace PlexisNsbSample
{
	/// <summary>
	/// Use this interface when you want to specify message handling order
	/// </summary>
	public interface IOrderHandlers
	{
		/// <summary>
		/// The order in which to handle messages
		/// </summary>
		/// <returns></returns>
		void SpecifyOrder(Order order);
	}

	/// <summary>
	/// Used to specify the order in which message handlers will be activated.
	/// </summary>
	public class Order
	{
		private readonly ConfigUnicastBus cfg;

		public Order(ConfigUnicastBus config)
		{
			cfg = config;
		}

		/// <summary>
		/// Specifies that the given type will be activated before all others.
		/// </summary>
		/// <typeparam name="TFirst"></typeparam>
		public void Specify<TFirst>()
		{
			cfg.LoadMessageHandlers<TFirst>();
		}

		/// <summary>
		/// Specifies an ordering of multiple types using the syntax:
		/// First{H1}.Then{H2}().Then{H3}()... etc
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ordering"></param>
		public void Specify<T>(First<T> ordering)
		{
			cfg.LoadMessageHandlers(ordering);
		}
	}
}