.\bin\windows\zookeeper-server-start.bat config\zookeeper.properties  --Step 1
.\bin\windows\kafka-server-start.bat config\server.properties -- Step 2
.\bin\windows\kafka-topics.bat --create --topic test --bootstrap-server localhost:9092
.\bin\windows\kafka-server-stop.bat
.\bin\windows\zookeeper-server-stop.bat
.\bin\windows\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic test --from-beginning

.\bin\windows\kafka-topics.bat --create --topic testdata --bootstrap-server localhost:9092
.bin\windows>kafka-console-producer.bat --broker-list localhost:9092 --topic testdata

.\bin\windows\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic testdata --from-beginning
.\bin\windows\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic testdata --from-beginning -- Step 3
