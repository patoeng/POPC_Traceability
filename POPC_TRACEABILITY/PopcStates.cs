namespace POPC_TRACEABILITY
{
    public enum  PopcStates
    {
        Idle,
        WaitingForProcessable,
        WaitingForStartTestTimer,
        TestSequence1,
        TestSequence2,
        TestPass,
        TestFailNeedRetry,
        TestFailConfirmed,
        Done
    }
}
