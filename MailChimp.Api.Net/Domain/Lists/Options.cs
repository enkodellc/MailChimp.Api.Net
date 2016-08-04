using System.Collections.Generic;
using MailChimp.Api.Net.Domain.Campaigns;
using MailChimp.Api.Net.Enum;

namespace MailChimp.Api.Net.Domain.Lists
{
  public class Options
  {
    public int size { get; set; }
    public Match match { get; set; }
    public List<Condition> conditions { get; set; }
  }
}