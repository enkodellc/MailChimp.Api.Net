using System;
using System.Net.Http;
using System.Threading.Tasks;
using MailChimp.Api.Net.Domain.Campaigns;
using MailChimp.Api.Net.Domain.Feedback;
using MailChimp.Api.Net.Enum;


namespace MailChimp.Api.Net.Services.Campaigns
{
  // ==================================================================================================================================================
  // AUTHOR      : Shahriar Hossain
  // PURPOSE     : Campaigns are how you send emails to your MailChimp list. Use the Campaigns API calls to manage campaigns in your MailChimp account.
  // ===================================================================================================================================================
  public class MailChimpCampaigns
  {
    private MCCampaignsOverview overview;
    private MCCampaignContent campaignContent;
    private MCCampaignsFeedback feedback;
    private MCCampaignsCheckList checkList;
    private MCCampaignSchedule scheduleCampaign;

    public MailChimpCampaigns()
    {
      overview = new MCCampaignsOverview();
      campaignContent = new MCCampaignContent();
      feedback = new MCCampaignsFeedback();
      checkList = new MCCampaignsCheckList();
      scheduleCampaign = new MCCampaignSchedule();
    }

    #region overview

    /// <summary>
    /// Create a new campaign
    /// <param name="campaignType">Possible Value : regular, plaintext, absplit, rss, variate </param>
    /// <param name="CampaignRecipient"></param>
    /// <param name="campaignTracking"></param>
    /// <param name="campaignTracking"></param>
    /// </summary>
    public async Task<dynamic> CreateCampaign(CampaignType campaignType,
                                              Recipients CampaignRecipient,
                                              Settings campaignSettings,
                                              Tracking campaignTracking)
    {
      return await overview.CreateCampaign(campaignType, CampaignRecipient, campaignSettings, campaignTracking);
    }


    /// <summary>
    /// Get all campaigns
    /// </summary>
    public async Task<RootCampaign> GetAllCampaigns()
    {
      return await overview.GetAllCampaigns();
    }

    /// <summary>
    /// Get information about a specific campaign
    /// <param name="campaignId">Unique id for the campaign</param>
    /// </summary>
    public async Task<Campaign> GetCampaign(string campaignId)
    {
      return await overview.GetCampaign(campaignId);
    }

    /// <summary>
    /// Delete a campaign
    /// <param name="campaignId">Unique id for the campaign</param>
    /// </summary>
    public async Task<HttpResponseMessage> DeleteCampaign(string campaignId)
    {
      return await overview.DeleteCampaign(campaignId);
    }

    /// <summary>
    /// Cancel a campaign
    /// <param name="campaignId">Unique id for the campaign</param>
    /// </summary>
    public async Task<HttpResponseMessage> CancelCampaign(string campaignId)
    {
      return await overview.CancelCampaign(campaignId);
    }

    /// <summary>
    /// Send a campaign
    /// <param name="campaignId">Unique id for the campaign</param>
    /// </summary>
    public async Task<dynamic> SendCampaign(string campaignId)
    {
      return await overview.SendCampaign(campaignId);
    }

    #endregion overview

    #region campaignContent

    ///<summary>
    ///Get campaign content
    ///</summary>
    public async Task<RootContent> GetContent(string campaign_id)
    {
      return await campaignContent.GetCampaignContent(campaign_id);
    }

    ///<summary>
    ///Set campaign content
    ///</summary>
    [Obsolete("Use other overloaded version of SetCampaignContent()", true)]
    public async Task<dynamic> SetCampaignContent(string campaign_id, ContentSetting setting,
                                                  ContentTemplate contentTemplate)
    {
      return await campaignContent.SetCampaignContent(campaign_id, setting, contentTemplate);
    }


    ///<summary>
    ///Set campaign content
    ///</summary>
    public async Task<dynamic> SetCampaignContent(string campaign_id, ContentSetting setting)
    {
      return await campaignContent.SetCampaignContent(campaign_id, setting);
    }

    ///<summary>
    ///Set campaign content
    ///</summary>
    public async Task<dynamic> SetCampaignContent(string campaign_id, ContentTemplate contentTemplate)
    {
      return await campaignContent.SetCampaignContent(campaign_id, contentTemplate);
    }

    #endregion campaignContent

    #region feedback

    /// <summary>
    /// Get feedback about a campaign
    /// <param name="campaignId">Unique id for the campaign</param>
    /// </summary>
    public async Task<RootFeedback> GetCampaignFeedback(string campaignId)
    {
      return await feedback.GetCampaignFeedback(campaignId);
    }

    /// <summary>
    /// Get feedback about a campaign
    /// <param name="campaignId">Unique id for the campaign</param>
    /// <param name="feedback_id">Unique id for the feedback message.</param>
    /// </summary>
    public async Task<Feedback> GetFeedback(string campaignId, string feedback_id)
    {
      return await feedback.GetFeedback(campaignId, feedback_id);
    }

    /// <summary>
    /// Delete a campaign feedback message
    /// <param name="campaignId">Unique id for the campaign</param>
    /// <param name="feedback_id">Unique id for the feedback message.</param>
    /// </summary>
    public async Task<HttpResponseMessage> DeleteFeedback(string campaignId, string feedback_id)
    {
      return await feedback.DeleteFeedback(campaignId, feedback_id);
    }

    #endregion feedback

    #region checkList

    /// <summary>
    /// Get the send checklist for a campaign
    /// <param name="campaign_id">Unique id for the campaign</param>
    /// </summary>
    [Obsolete("MethodName is misleading, USE GetCheckList() instead.")]
    public async Task<RootCheckList> GetCampaignContent(string campaign_id)
    {
      return await checkList.GetCampaignContent(campaign_id);
    }

    /// <summary>
    /// Get the send checklist for a campaign
    /// <param name="campaign_id">Unique id for the campaign</param>
    /// </summary>
    public async Task<RootCheckList> GetCheckList(string campaign_id)
    {
      return await checkList.GetCheckList(campaign_id);
    }

    #endregion checkList

    #region schedule 

    /// <summary>
    /// Schedule Campaign Blast time
    /// <param name="campaign_id">Unique id for the campaign</param>
    /// <param name="dateTime">Schedule time in UTC format</param>
    /// </summary>
    public async Task<dynamic> ScheduleCampaign(string campaign_id, DateTime dateTime)
    {
      return await scheduleCampaign.ScheduleCampaign(campaign_id, dateTime);
    }

    #endregion schedule 
  }
}