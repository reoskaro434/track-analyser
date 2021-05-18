namespace TrackAnalyser.Utilities.DataInitializer
{
    public interface IDatabaseInitializer<TUnitOfWork> where TUnitOfWork : class
    {
        /// <summary>
        /// Initialize DB for program presentation.
        /// </summary>
        public void SetDatabase();
    }
}
