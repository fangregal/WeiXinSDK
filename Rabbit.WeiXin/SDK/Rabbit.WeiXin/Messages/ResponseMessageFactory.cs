﻿using Rabbit.WeiXin.Messages.Response;
using Rabbit.WeiXin.Serialization;

namespace Rabbit.WeiXin.Messages
{
    /// <summary>
    /// 一个抽象的响应消息工厂。
    /// </summary>
    public interface IResponseMessageFactory
    {
        /// <summary>
        /// 根据相应消息得到xml内容。
        /// </summary>
        /// <param name="responseMessage">响应消息实例。</param>
        /// <returns>xml内容。</returns>
        string GetXmlByReponseMessage(IResponseMessage responseMessage);
    }

    /// <summary>
    /// 响应消息工厂实现。
    /// </summary>
    internal sealed class ResponseMessageFactory : IResponseMessageFactory
    {
        #region Field

        private readonly IMessageFormatterFactory _messageFormatterFactory;

        #endregion Field

        #region Constructor

        public ResponseMessageFactory(IMessageFormatterFactory messageFormatterFactory)
        {
            _messageFormatterFactory = messageFormatterFactory;
        }

        #endregion Constructor

        #region Implementation of IResponseMessageFactory

        /// <summary>
        /// 根据相应消息得到xml内容。
        /// </summary>
        /// <param name="responseMessage">响应消息实例。</param>
        /// <returns>xml内容。</returns>
        public string GetXmlByReponseMessage(IResponseMessage responseMessage)
        {
            return _messageFormatterFactory.GetFormatter(responseMessage.MessageType).Serialize(responseMessage);
        }

        #endregion Implementation of IResponseMessageFactory
    }
}