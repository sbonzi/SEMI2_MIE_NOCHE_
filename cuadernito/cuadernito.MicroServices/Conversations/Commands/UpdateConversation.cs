﻿namespace cuadernito.MicroServices.Conversations.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Cqrs.Commands;

    /// <summary>
    /// A <see cref="ICommand{TAuthenticationToken}"/> that instructs the <see cref="Conversation"/> to update its name.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UpdateConversation : ICommand<Guid>
    {
        #region Implementation of IMessage

        [DataMember]
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// The originating framework this message was sent from.
        /// </summary>
        [DataMember]
        public string OriginatingFramework { get; set; }

        /// <summary>
        /// The frameworks this <see cref="T:Cqrs.Messages.IMessage"/> has been delivered to/sent via already.
        /// </summary>
        [DataMember]
        public IEnumerable<string> Frameworks { get; set; }

        #endregion

        #region Implementation of IMessageWithAuthenticationToken<Guid>

        [DataMember]
        public Guid AuthenticationToken { get; set; }

        #endregion

        #region Implementation of ICommand<Guid>

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public int ExpectedVersion { get; set; }

        #endregion

        /// <summary>
        /// The conversation that is being updated.
        /// </summary>
        [DataMember]
        public Guid Rsn { get; set; }

        /// <summary>
        /// The name of the conversation.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}