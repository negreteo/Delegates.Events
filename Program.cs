using System;

namespace Delegates.Events
{
  class Program
  {
    static void Main (string[] args)
    {
      // DelegateWorkPerformedHandler delegate1 = new DelegateWorkPerformedHandler (DelegateMethod_WorkPerformed1);
      // DelegateWorkPerformedHandler delegate2 = new DelegateWorkPerformedHandler (DelegateMethod_WorkPerformed2);
      // DelegateWorkPerformedHandler delegate3 = new DelegateWorkPerformedHandler (DelegateMethod_WorkPerformed3);

      // //delegate1 (4, WorkType.GenerateReports);
      // //delegate2 (5, WorkType.GoToMeetings);

      // //DoWork (delegate1);

      // // Multicast
      // delegate1 += delegate2 + delegate3;

      // int finalHours = delegate1 (8, WorkType.Golf);
      // System.Console.WriteLine ($"Final Hours: {finalHours}");

      var worker = new Worker ();
      // Wire up delegate into the worker
      //worker.EventWorkPerformed += new EventHandler<WorkPerformedEventArgs> (Worker_WorkPerformed);
      //worker.EventWorkCompleted += new EventHandler (Worker_WorkCompleted);

      worker.EventWorkPerformed += Worker_WorkPerformed; // delegate inference or
      worker.EventWorkCompleted += delegate (object sender, EventArgs e) // using anonymous method
      {
        System.Console.WriteLine ($"Work completed");
      };

      worker.DoWork (8, WorkType.GoToMeetings);
    }

    // Call back
    static void Worker_WorkPerformed (object sender, WorkPerformedEventArgs e)
    {
      System.Console.WriteLine ($"Worked hours: {e.Hours}, on Work Type: {e.WorkType}");
    }

    // static int DelegateMethod_WorkPerformed1 (int hours, WorkType workType)
    // {
    //   System.Console.WriteLine ($"Worked Performed 1: {workType} for {hours} hours");
    //   return hours + 1;
    // } // WorkPerformed1

    // static int DelegateMethod_WorkPerformed2 (int hours, WorkType workType)
    // {
    //   System.Console.WriteLine ($"Worked Performed 2: {workType} for {hours} hours");
    //   return hours + 2;
    // } 

    // static int DelegateMethod_WorkPerformed3 (int hours, WorkType workType)
    // {
    //   System.Console.WriteLine ($"Worked Performed 3: {workType} for {hours} hours");
    //   return hours + 3;
    // } 

    // static void DoWork (DelegateWorkPerformedHandler delegate1)
    // {
    //   delegate1 (5, WorkType.GoToMeetings);
    // } 

  } // Program

  public enum WorkType
  {
    GoToMeetings,
    Golf,
    GenerateReports
  }

}
