# ETW

# I. MyApplication (Producer) 

# II. Collect (Controller)
## 1. xperf 
   write to file
```shell
# prefix the provider name with *
# start tracing
# will write trace1.etl file
xperf -start trace -f trace2.etl -on *Microsoft-EtwDemo

# Stop tracing
xperf -stop trace
```

## 2. traceview
trace with `*[providerName]`

# III. View Trace Data (Consumer)
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


List providers:  
https://hannahsuarez.github.io/2019/List-of-ETW-Providers/

c:\Windows\System32\logman.exe query providers

# Extra
Windows Performance Recorder (Included in the Windows Assessment and Deployment Kit (Windows ADK))


# Code

**Event Id** and **Provider name**

In the Event Tracing for Windows (ETW) system, the provider name and event ID work together to uniquely identify and
categorize events. Let's break down the relationship between the provider name and event ID:

Provider Name:

The provider name is a string identifier associated with an EventSource or a provider of ETW events. It helps identify
the source or origin of the events.
The provider name is set when you define your EventSource class using the Name property of the [EventSource] attribute.
For example:

```csharp

[EventSource(Name = "MyLogger")]
public class MyLogger : EventSource
{
// ... events and methods
}

```
The provider name is crucial for uniquely identifying where the events are coming from when you have multiple providers
emitting events.
Event ID:

The event ID is a unique numeric identifier associated with each event within a specific provider. It distinguishes
different types of events emitted by the same EventSource.
Event IDs are assigned when you define events using the [Event] attribute. For example:

```csharp

[Event(1, Message = "CustomEvent: {0} milliseconds", Level = EventLevel.Informational)]
public void CustomEvent(TimeSpan duration)
{
    if (IsEnabled())
    {
        WriteEvent(1, duration.TotalMilliseconds);
    }
}
```
Event IDs must be unique within the scope of a particular EventSource. They are used to differentiate one event from
another within the same provider.
Usage in ETW:

When events are emitted by an EventSource, they are tagged with the provider name and event ID.
Consumers of ETW events, such as monitoring tools or log analyzers, can use the provider name and event ID to filter and
categorize the events. This allows users to focus on specific events emitted by specific providers.
In summary, the combination of the provider name and event ID provides a unique identifier for each event in the ETW
system. The provider name helps identify the source of events, and the event ID distinguishes between different types of
events emitted by the same source. This information is crucial for understanding and analyzing the events captured by
ETW consumers.

# Use case AMR perf tracking
1. Receiver/ Sender queue length
2. ElapsedSincePrevPublisher
3. ElapsedSinceMsgOriginator
4. publisher counter
5. receiver counter

+ AMT histogram log