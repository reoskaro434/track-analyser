using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.BroadcastFilter
{
    public interface IBroadcastFilter<TModel,TUnitOfWork>
        where TModel : class 
        where TUnitOfWork : class     
    {
        /// <summary>
        /// Returns emissions of the tracks according to given text.
        /// </summary>
        /// <param name="text">Allow to filter emissions by track name.</param>
        /// <returns>View model.</returns>
        public Task<TModel> GetModelAsync(string text = "");
    }
}
