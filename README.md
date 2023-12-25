# ETW


tools:

traceview (GUI)



xperf 
   write to file
```
# prefix the provider name with *
xperf -start trace -f trace1.etl -on *Microsoft-EtwDemo
```


will write trace1.etl file


tracefmt write to console
```
tracefmt -displayonly trace1.etl
```
![image](https://github.com/yhan/ETW/assets/760399/d3cc4d45-5219-4c1c-b795-fd1ed943a4da)


![image](https://github.com/yhan/ETW/assets/760399/951081e3-5a08-4bb6-8ce9-c1416c28521d)


