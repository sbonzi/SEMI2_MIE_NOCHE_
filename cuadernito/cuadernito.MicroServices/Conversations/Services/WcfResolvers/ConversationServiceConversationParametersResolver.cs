﻿namespace cuadernito.MicroServices.Conversations.Services.WcfResolvers
{
    using Cqrs.Events;
    using Cqrs.Services;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml;

    /// <summary>
    /// A <see cref="DataContractResolver"/> for using <see cref="IConversationService.GetMessages"/> or <see cref="IConversationService.DeleteConversation"/> via WCF
    /// </summary>
    public class ConversationServiceConversationParametersResolver : BasicServiceParameterResolver<IConversationService, Guid>
    {
        public ConversationServiceConversationParametersResolver()
            : base(new EventDataResolver<Guid>())
        {
        }

        public override bool TryResolveType(Type dataContractType, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            if (dataContractType == typeof(ServiceRequestWithData<Guid, ConversationService.ConversationParameters>))
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add("ConversationServiceConversationParameters");
                typeNamespace = dictionary.Add(ServiceNamespace);
                return true;
            }

            if (dataContractType == typeof(ServiceResponseWithResultData<IEnumerable<MessageEntity>>))
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add("ConversationServiceGetMessagesResponse");
                typeNamespace = dictionary.Add(ServiceNamespace);
                return true;
            }

            if (dataContractType == typeof(ServiceResponseWithResultData<IEnumerable<ConversationSummaryEntity>>))
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add("ConversationServiceGetResponse");
                typeNamespace = dictionary.Add(ServiceNamespace);
                return true;
            }

            if (dataContractType == typeof(ServiceResponse))
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add("ConversationServiceDeleteConversationResponse");
                typeNamespace = dictionary.Add(ServiceNamespace);
                return true;
            }

            return base.TryResolveType(dataContractType, declaredType, knownTypeResolver, out typeName, out typeNamespace);
        }

        protected override bool TryResolveUnResolvedType(Type dataContractType, Type declaredType, DataContractResolver knownTypeResolver, ref XmlDictionaryString typeName, ref XmlDictionaryString typeNamespace)
        {
            return false;
        }

        /// <summary>
        /// Override this method to map the specified xsi:type name and namespace to a data contract type during deserialization.
        /// </summary>
        /// <returns>
        /// The type the xsi:type name and namespace is mapped to. 
        /// </returns>
        /// <param name="typeName">The xsi:type name to map.</param><param name="typeNamespace">The xsi:type namespace to map.</param><param name="declaredType">The type declared in the data contract.</param><param name="knownTypeResolver">The known type resolver.</param>
        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            if (typeNamespace == ServiceNamespace)
            {
                if (typeName == "ConversationServiceConversationParameters")
                    return typeof(ServiceRequestWithData<Guid, ConversationService.ConversationParameters>);
                if (typeName == "ConversationServiceGetMessagesResponse")
                    return typeof(ServiceResponseWithResultData<IEnumerable<MessageEntity>>);
                if (typeName == "ConversationServiceGetResponse")
                    return typeof(ServiceResponseWithResultData<IEnumerable<ConversationSummaryEntity>>);
                if (typeName == "ConversationServiceDeleteConversationResponse")
                    return typeof(ServiceResponse);
            }

            return base.ResolveName(typeName, typeNamespace, declaredType, knownTypeResolver);
        }

        protected override Type ResolveUnResolvedName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            return null;
        }

        public static void RegisterDataContracts()
        {
            WcfDataContractResolverConfiguration.Current.RegisterDataContract<IConversationService, ConversationServiceConversationParametersResolver>("Get");
            WcfDataContractResolverConfiguration.Current.RegisterDataContract<IConversationService, ConversationServiceConversationParametersResolver>("GetMessages");
            WcfDataContractResolverConfiguration.Current.RegisterDataContract<IConversationService, ConversationServiceConversationParametersResolver>("DeleteConversation");
        }
    }
}