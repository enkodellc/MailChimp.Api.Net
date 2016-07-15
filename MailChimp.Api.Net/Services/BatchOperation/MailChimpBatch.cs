using System.Threading.Tasks;
using MailChimp.Api.Net.Domain.BatchOperation;

namespace MailChimp.Api.Net.Services.BatchOperation
{
  public class MailChimpBatch
  {
    // =====================================================================================
    // AUTHOR      : Shahriar Hossain
    // PURPOSE     : Use batch operations to complete multiple operations with a single call.
    // =====================================================================================

    private MCBatch batch;

    public MailChimpBatch()
    {
      batch = new MCBatch();
    }

    /// <summary>
    /// Start a batch operation
    /// <param name="bundle"></param>
    /// </summary>
    public async Task<dynamic> PostBatchOperation(RootBatch bundle)
    {
      return await batch.PostBatchOperation(bundle);
    }


    /// <summary>
    /// Get the status of a batch operation request
    /// <param name="batchId">The unique id for the batch operation</param>
    /// </summary>
    public async Task<RootBatch> GetBatchReport(string batchId)
    {
      return await batch.GetBatchReport(batchId);
    }
  }
}