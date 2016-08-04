using System.Collections.Generic;
using MailChimp.Api.Net.Enum;

namespace MailChimp.Api.Net.Domain.Campaigns
{
  public class SegmentOpts
  {
    public int saved_segment_id { get; set; }
    public Match match { get; set; }
    public List<Condition> conditions { get; set; }
  }
}