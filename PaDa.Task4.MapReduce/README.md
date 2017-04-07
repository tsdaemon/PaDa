## Generic map reduce with spark-like API

I decided to create a generic API for this task, inspired by Java SPARK API. It looks pretty ugly now and involves a lot of reflection black magic 
with low performance. Also tests show some data corruptions occur from time to time, so it still unstable. But it can be used for basic set of 
operations like map, map to pair and reduce by key.