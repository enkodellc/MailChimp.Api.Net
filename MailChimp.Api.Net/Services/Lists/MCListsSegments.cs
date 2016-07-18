using System;
using System.Net.Http;
using System.Threading.Tasks;
using MailChimp.Api.Net.Domain.Lists;
using MailChimp.Api.Net.Enum;
using Newtonsoft.Json;

namespace MailChimp.Api.Net.Services.Lists
{
  // ==================================================================
  // AUTHOR      : Shahriar Hossain
  // PURPOSE     : Manage segments for a specific MailChimp list.
  // ==================================================================

  internal class MCListsSegments
  {
    /// <summary>
    /// Get information about all segments in a list
    /// <param name="list_id">Unique id for the list</param>
    /// </summary>
    internal async Task<RootSegment> GetAllSegmentsAsync(string list_id)
    {
      string endpoint = Authenticate.EndPoint(TargetTypes.lists, SubTargetType.segments, SubTargetType.not_applicable,
                                              list_id);

      string content;
      using (var client = new HttpClient())
      {
        Authenticate.ClientAuthentication(client);

        content = await client.GetStringAsync(endpoint).ConfigureAwait(false);
      }

      return JsonConvert.DeserializeObject<RootSegment>(content);
    }

    /// <summary>
    /// Get information about a specific segment
    /// <param name="list_id">Unique id for the list</param>
    /// <param name="segment_id">Unique id for the segment</param>
    /// </summary>
    internal async Task<RootSegment> GetSegmentInfoAsync(string list_id, string segment_id)
    {
      string endpoint = Authenticate.EndPoint(TargetTypes.lists, SubTargetType.segments, SubTargetType.not_applicable,
                                              list_id, segment_id);

      string content;
      using (var client = new HttpClient())
      {
        Authenticate.ClientAuthentication(client);

        content = await client.GetStringAsync(endpoint).ConfigureAwait(false);
      }

      return JsonConvert.DeserializeObject<RootSegment>(content);
    }

    /// <summary>
    /// Delete a segment
    /// <param name="list_id">Unique id for the list</param>
    /// <param name="segment_id">The segment id to get</param>
    /// </summary>
    internal async Task<HttpResponseMessage> DeleteSegmentAsync(string list_id, string segment_id)
    {
      string endpoint = Authenticate.EndPoint(TargetTypes.lists, SubTargetType.segments, SubTargetType.not_applicable,
                                              list_id, segment_id);

      HttpResponseMessage result;
      using (var client = new HttpClient())
      {
        try
        {
          Authenticate.ClientAuthentication(client);

          result = await client.DeleteAsync(endpoint).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
      return result;
    }
  }
}