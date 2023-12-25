# ETW

# Collect
## xperf 
   write to file
```shell
# prefix the provider name with *
# start tracing
# will write trace1.etl file
xperf -start trace -f trace2.etl -on *Microsoft-EtwDemo

# Stop tracing
xperf -stop trace
```

## traceview
trace with `*[providerName]`


# View Trace Data
## tracefmt
```shell
#write to console
tracefmt -displayonly trace1.etl
```
## perfview
load etl file

## traceview
load etl file


![image](https://github.com/yhan/ETW/assets/760399/d3cc4d45-5219-4c1c-b795-fd1ed943a4da)


![image](https://github.com/yhan/ETW/assets/760399/951081e3-5a08-4bb6-8ce9-c1416c28521d)


Recap:

![image](https://github.com/yhan/ETW/assets/760399/2ac48bd2-6651-4515-a5b3-a89d55c81fb1)



