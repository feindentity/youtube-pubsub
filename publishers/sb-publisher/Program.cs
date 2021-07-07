using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
namespace sb_publisher
{

//write to a topic 
    public class sbpub
    {
       static string connectionString = "Endpoint=https://pubsubpoc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Yy4+uTSv/6TN0gy5FvDRATUTOufM0FPECOT3CNPl1I8=;";
       static string topicName = "sb-publisher-code-spaces";
       static ServiceBusClient sbClient;
       static ServiceBusSender sbSender;
       private const int numOfMessages = 3;

        static async Task Main(string[] args)
        {
        
            var sbOptions = new ServiceBusClientOptions();
            sbOptions.TransportType =ServiceBusTransportType.AmqpWebSockets;
          
             sbClient = new ServiceBusClient(connectionString, sbOptions);
        
             sbSender = sbClient.CreateSender(topicName);
             
                      
                       using ServiceBusMessageBatch messageBatch = await sbSender.CreateMessageBatchAsync();

            for (int i = 1; i <= 3; i++)
            {
                // try adding a message to the batch
                if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
                {
                    // if it is too large for the batch
                    throw new Exception($"The message {i} is too large to fit in the batch.");
                }
            }

            try
            {
                // Use the producer client to send the batch of messages to the Service Bus topic
                await sbSender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"A batch of {numOfMessages} messages has been published to the topic.");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sbSender.DisposeAsync();
                await sbClient.DisposeAsync();
            }

            Console.WriteLine("Press any key to end the application");
            Console.ReadKey();
            return;
        }
    }
}
