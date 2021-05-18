namespace TrackAnalyser.Utilities.Rank
{
    public interface IRank<TModel, TUnitOfWork> 
        where TModel : class
        where TUnitOfWork : class
    {
        /// <summary>
        /// Returns top played songs.
        /// </summary>
        /// <param name="maxSize">Max size of rank.</param>
        /// <returns>RankViewModel</returns>
        public TModel GetRank(int maxSize);
    }
}
