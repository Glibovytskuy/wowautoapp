using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace WowAutoApp.Core.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Represents the event publisher implementation
    /// </summary>
    public class EventPublisher : IEventPublisher
    {
        /// <summary>
        /// Gets or sets service provider
        /// </summary>
        private IServiceProvider _serviceProvider { get; }
        public EventPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        /// <summary>
        /// Publish event to consumers
        /// </summary>
        /// <typeparam name="TEvent">Type of event</typeparam>
        /// <param name="event">Event object</param>
        public void Publish<TEvent>(TEvent @event)
        {
            //get all event consumers
            var consumers = (IEnumerable<IConsumer<TEvent>>)_serviceProvider.GetServices(typeof(IConsumer<TEvent>));

            //handle published event
            foreach (var consumer in consumers)
                consumer.HandleEvent(@event);
        }
    }
}