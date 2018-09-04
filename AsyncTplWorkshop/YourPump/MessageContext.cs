using System.Collections.Generic;

namespace AsyncTplWorkshop.YourPump
{
    public class MessageContext
    {
        public MessageContext()
        {
            var id = CombGuid.Generate().ToString();

            Headers = new Dictionary<string, string>
            {
                {HeaderKeys.MessageId, id},
            };
        }

        public MessageContext(MessageContext message)
        {
            Headers = new Dictionary<string, string>
            {
                {HeaderKeys.MessageId, message.Id},
            };

            foreach (var pair in message.Headers)
            {
                if (!Headers.ContainsKey(pair.Key))
                {
                    Headers.Add(pair.Key, pair.Value);
                }
            }
        }

        public string Id => Headers[HeaderKeys.MessageId];

        public Dictionary<string, string> Headers { get; }
    }
}