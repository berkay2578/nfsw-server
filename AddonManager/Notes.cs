namespace AddonManager
{
    internal sealed class Notes
    {
        /*
         * This class is not to be taken serious.
         * It is for other GitHub coders to easily remember and see what's missing or needs fixing.
         * It will be deleted after what has been written here is fixed or done.
         * Bugs that are currently on my head:
         * 1. None.
         * --
         * Features that need to be done quick:
         * 1. ERROR HANDLING. Currently there is moderate handling, and users will (indubitably) manage to hit every error, because, people.
         * 2. Change language so that it automatically reads and outputs every single node like:
         * /--------------------------------------------------------------------------\
         * | Label  | Value                        | Sample (strfrm with dialog)      |
         * |------------|--------------------------|----------------------------------|
         * | Boost  | {0} has {1} boost.           | Example has example2 boost.      |
         * | Boost2 | '{0}', you have {1:c} boost. |  'Example', you have $999 boost. |
         * \--------------------------------------------------------------------------/
         * 3. Kind of a long shot, and probably will take a long time, but maybe add visual info to the language tab?
         * -> Like, if the AddonManager was launched from the OfflineServer auto highlight UI element of active node.
         * 4. Memory Patcher, just fuck all at this stage. Needs active code compiling into static-load-library.
         * -> OfflineServer will have its own in-game UI with injection, memory patches will have options etcetra there.
         * --> Yeah, need me some unamanaged code here, not sure if I wanna stick to c# for this.
         * ---> However, if I don't, then other people without the knowledge won't be able to write shit. 
         * ----> I've seen hackers with 0 coding knowledge, it still amazes me that they exist, though.
         * -----> If I define a standard __dllMain() with example code, those people WILL fail to do anything. God have mercy on me.
         * 5. FOR OFFLINE SERVER --- Circa NFS:World beta times, game had local defined contests with bots. Maybe code in timed events, like for Christmas.
         * 6. Buy booze.
         */
    }
}