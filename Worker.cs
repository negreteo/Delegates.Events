using System;

namespace Delegates.Events
{
  // Delegate definition, pipeline
  // The word "Handler" is tipycally used to name delegates
  //public delegate int DelegateWorkPerformedHandler (object sender, WorkPerformedEventArgs e);

  public class Worker
  {
    //public event DelegateWorkPerformedHandler EventWorkPerformed;
    public event EventHandler<WorkPerformedEventArgs> EventWorkPerformed; // Eliminates delegate declaration
    public event EventHandler EventWorkCompleted;

    public void DoWork (int hours, WorkType workType)
    {
      for (int i = 0; i < hours; i++)
      {
        System.Threading.Thread.Sleep (1000);
        RaiseEvent_OnWorkPerformed (i, workType);
      }

      RaiseEvent_OnWorkCompleted ();
    }

    // Raise events methods are prefixed with "On" or "Raised"
    protected virtual void RaiseEvent_OnWorkPerformed (int hours, WorkType workType)
    {
      // Technique 1
      if (EventWorkPerformed != null) EventWorkPerformed (this, new WorkPerformedEventArgs (hours, workType));

      // Technique 2, casting the event as the delegate
      //var delegate1 = EventWorkPerformed as EventHandler<WorkPerformedEventArgs>;
      //if (delegate1 != null) delegate1 (this, new WorkPerformedEventArgs (hours, workType));
    }

    // Raise events methods are prefixed with "On" or "Raised"
    // EventHandler does not take arguments
    protected virtual void RaiseEvent_OnWorkCompleted ()
    {
      if (EventWorkCompleted != null) EventWorkCompleted (this, EventArgs.Empty);

      //var delegate1 = EventWorkCompleted as EventHandler;
      //if (delegate1 != null) delegate1 (this, EventArgs.Empty);
    }

  }
}
