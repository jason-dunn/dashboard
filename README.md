Dashboard emulates a cryptocurrency mining service reporting hub. Ten independent service workers are individually assigned a workload to complete.  Each service worker, a miner, follows an algorithm to simulate units/time to be fulfilled.  When the workload is complete, a report is sent to the hub updating the user interface and more work is distributed. 

A Microsoft.AspNet.SignalR hub class in the server project is used for receiving the update message from the sender client [Hub Functions](http://jasonisdunn.tech/send) and sending the message to the receiver client [Hub Dashboard](http://jasonisdunn.tech/raw/?) .

(To preview the example you will need to load two seperate tabs using any desktop browser. (Not mobile or tablet)
[Hub Functions](http://jasonisdunn.tech/send) and [Hub Dashboard](http://jasonisdunn.tech/raw/?))

The resulting grid displays the current data queried from multiple tables in the SQL database. A Microsoft.EntityFrameworkCore dbcontext class in the server project is used for real time data streaming. The grid also displays the status of each miner. A miner can be off-line, not mining, mining normal or mining aggressive. 

If you get to here [jasonisdunn.tech](http://jasonisdunn.tech) select a language and enter the code “123456”. 
