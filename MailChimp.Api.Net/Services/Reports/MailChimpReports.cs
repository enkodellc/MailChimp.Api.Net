using System.Threading.Tasks;
using MailChimp.Api.Net.Domain.Reports;

namespace MailChimp.Api.Net.Services.Reports
{
  public class MailChimpReports
  {
    private MCReportsOverview reportOverview;
    private MCReportsCampaignAdvice campaign;
    private MCReportsClickDetails clickDetails;
    private MCReportsDomainPerformance performance;
    private MCReportsEepURL eepUrl;
    private MCReportsEmailActivity emailActivity;
    private MCReportsLocation location;
    private MCReportsSentTo sentTo;
    private MCReportsSubReport subReport;
    private MCReportsUnsubscribes unsubscribe;

    public MailChimpReports()
    {
      reportOverview = new MCReportsOverview();
      campaign = new MCReportsCampaignAdvice();
      clickDetails = new MCReportsClickDetails();
      performance = new MCReportsDomainPerformance();
      eepUrl = new MCReportsEepURL();
      emailActivity = new MCReportsEmailActivity();
      location = new MCReportsLocation();
      sentTo = new MCReportsSentTo();
      subReport = new MCReportsSubReport();
      unsubscribe = new MCReportsUnsubscribes();
    }

    /// <summary>
    /// Get campaign reports
    /// </summary>
    public async Task<ReportOverview> GetOverview()
    {
      return await reportOverview.Overview();
    }

    /// <summary>
    /// Get a specific campaign report
    /// <param name="campaignId">Campaign Id</param>
    /// </summary>
    public async Task<ReportOverview_Campaign> GetOverviewByCampaign(string campaignId)
    {
      return await reportOverview.CampaignOverview(campaignId);
    }

    /// <summary>
    /// Return recent feedback based on a campaign’s statistics
    /// <param name="campaignId">Campaign Id</param>
    /// </summary>
    public async Task<CampaignAdvice> GetAdvice(string campaignId)
    {
      return await campaign.GetAdvice(campaignId);
    }

    /// <summary>
    /// Return detailed information about links clicked in campaigns.
    /// <param name="campaignId">Campaign Id</param>
    /// </summary>
    public async Task<ClickReports> GetClickDetails(string campaignId)
    {
      return await clickDetails.GetClickDetails(campaignId);
    }

    /// <summary>
    /// Return click details for a specific link
    /// <param name="campaignId">Campaign Id</param>
    /// <param name="linkId">The id for the link.</param>
    /// </summary>
    public async Task<ClickReports> GetClickDetailByLinkId(string campaignId, string linkId)
    {
      return await clickDetails.GetLinkClickDetails(campaignId, linkId);
    }

    /// <summary>
    /// Return click details for a specific link
    /// <param name="campaignId">Campaign Id</param>
    /// <param name="linkId">The id for the link</param>
    /// </summary>
    public async Task<ClickReports> GetAlllSubscribersInfo(string campaignId, string linkId)
    {
      return await clickDetails.GetAllSubscribersInfo(campaignId, linkId);
    }

    /// <summary>
    /// Return click details for a specific link
    /// <param name="campaignId">Campaign Id</param>
    /// <param name="linkId">The id for the link</param>
    /// <param name="subscriber_hash">The MD5 hash of the lowercase version of the list member’s email address</param>
    /// </summary>
    public async Task<ClickReports> GetSubscriberInfo(string campaignId, string linkId, string subscriber_hash)
    {
      return await clickDetails.GetSubscriberInfo(campaignId, linkId, subscriber_hash);
    }

    /// <summary>
    /// Return statistics for the top-performing domains from a campaign.
    /// <param name="campaignId">Unique id for campaign</param>
    /// </summary>
    public async Task<DomainPerformance> GetDomainPerformance(string campaignId)
    {
      return await performance.GetDomainPerformance(campaignId);
    }

    /// <summary>
    /// Return a summary of social activity for the campaign, tracked by EepURL.
    /// <param name="campaignId">Unique id for campaign</param>
    /// </summary>
    public async Task<Eepurl> GetEepUrlActivity(string campaignId)
    {
      return await eepUrl.GetEepUrlActivity(campaignId);
    }

    /// <summary>
    /// Return list member activity for a specific campaign
    /// <param name="campaignId">Unique id for the campaign</param>
    /// </summary>
    public async Task<EmailActivity> GetEmailActivity(string campaignId)
    {
      return await emailActivity.GetEmailActivity(campaignId);
    }

    /// <summary>
    /// Return list member activity for a specific campaign
    /// <param name="campaignId">Unique id for the campaign</param>
    /// <param name="subscriber_hash">The MD5 hash of the lowercase version of the list member’s email address</param>
    /// </summary>
    public async Task<EmailActivity> GetEmailActivityBySubscriber(string campaignId, string subscriber_hash)
    {
      return await emailActivity.GetSubscriberEmailActivity(campaignId, subscriber_hash);
    }

    /// <summary>
    /// Return top open locations for a specific campaign.
    /// <param name="campaignId">Unique id for the campaign</param>
    /// </summary>
    public async Task<RootLocation> GetTopLocation(string campaignId)
    {
      return await location.GetTopLocation(campaignId);
    }

    /// <summary>
    /// Return top open locations for a specific campaign.
    /// <param name="campaignId">Unique id for the campaign</param>
    /// </summary>
    public async Task<RootSentTo> GetRecipientsInfo(string campaignId)
    {
      return await sentTo.GetRecipientsInfo(campaignId);
    }

    /// <summary>
    /// Return top open locations for a specific campaign.
    /// <param name="campaignId">Unique id for the campaign</param>
    /// <param name="subscriber_hash">The MD5 hash of the lowercase version of the list member’s email address</param>
    /// </summary>
    public async Task<SentTo> GetCampaignRecipient(string campaignId, string subscriber_hash)
    {
      return await sentTo.GetCampaignRecipient(campaignId, subscriber_hash);
    }

    /// <summary>
    /// Return A list of reports for child campaigns of a specific parent campaign. 
    /// <param name="campaignId">Campaign Id</param>
    /// </summary>
    public async Task<Sub_Reports> GetReportForChildCampaign(string campaignId)
    {
      return await subReport.GetChildCampaignReports(campaignId);
    }

    /// <summary>
    /// Return statistics for the top-performing domains from a campaign.
    /// <param name="campaignId">Unique id for campaign</param>
    /// </summary>
    public async Task<RootUnsubscribe> GetUnsubscriberList(string campaignId)
    {
      return await unsubscribe.GetUnsubscriberList(campaignId);
    }

    /// <summary>
    /// Return top open locations for a specific campaign.
    /// <param name="campaignId">Unique id for the campaign</param>
    /// <param name="subscriber_hash">The MD5 hash of the lowercase version of the list member’s email address</param>
    /// </summary>
    public async Task<SentTo> GetUnsubscriberInfo(string campaignId, string subscriber_hash)
    {
      return await unsubscribe.GetUnsubscriberInfo(campaignId, subscriber_hash);
    }
  }
}