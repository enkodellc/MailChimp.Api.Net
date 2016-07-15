using System.Threading.Tasks;
using MailChimp.Api.Net.Domain.Automations;

namespace MailChimp.Api.Net.Services.Automation
{
  // ===============================================================================================
  // AUTHOR      : Shahriar Hossain
  // PURPOSE     : Use the Automation API calls to manage Automation workflows, emails, and queues.
  // ===============================================================================================
  public class MailChimpAutomation
  {
    private MCAutomationsOverview overview;
    private MCAutomationsEmails automationsemails;
    private MCAutomationsEmailsQueue emailQueue;
    private MCAutomationsRemoveSubscriber removedSubscriber;

    public MailChimpAutomation()
    {
      overview = new MCAutomationsOverview();
      automationsemails = new MCAutomationsEmails();
      emailQueue = new MCAutomationsEmailsQueue();
      removedSubscriber = new MCAutomationsRemoveSubscriber();
    }

    #region overview

    /// <summary>
    /// Get a list of Automations
    /// <param name="count">The number of Automations to retrieve. Default 10</param>
    /// </summary>
    public async Task<RootAutomation> GetAutomationList(int count = 10)
    {
      return await overview.GetAllAutomationLists(count);
    }

    /// <summary>
    /// Get information about a specific Automation workflow
    /// <param name="workflow_id">Unique id for the Automation workflow</param>
    /// </summary>
    internal async Task<MCAutomation> GetAutomation(string workflow_id)
    {
      return await overview.GetInfoByWorkflowId(workflow_id);
    }

    #endregion overview

    #region automationsemails

    /// <summary>
    /// Get a list of automated emails in a workflow
    /// <param name="workflow_id">Unique id for the Automation workflow</param>
    /// </summary>
    internal async Task<RootAutomationsEmail> GetAutomatedEmailList(string workflow_id)
    {
      return await automationsemails.GetAutomatedEmailList(workflow_id);
    }

    /// <summary>
    /// Get information about a specific workflow email
    /// <param name="workflow_id">Unique id for the Automation workflow</param>
    /// <param name="workflow_email_id">Unique id for the Automation workflow email</param>
    /// </summary>
    internal async Task<AutomationsEmail> GetWorkflowEmailInfo(string workflow_id, string workflow_email_id)
    {
      return await automationsemails.GetInfoForWorkflowEmail(workflow_id, workflow_email_id);
    }

    #endregion automationsemails

    #region emailQueue

    /// <summary>
    /// View queued subscribers for an automated email
    /// <param name="workflow_id">Unique id for the Automation workflow</param>
    /// <param name="workflow_email_id">Unique id for the Automation workflow email</param>
    /// </summary>
    internal async Task<RootAutomationsEmailQueue> GetQueuedSubscriberList(string workflow_id, string workflow_email_id)
    {
      return await emailQueue.GetQueuedSubscriberList(workflow_id, workflow_email_id);
    }

    /// <summary>
    /// View specific subscriber in email queue
    /// <param name="workflow_id">Unique id for the Automation workflow</param>
    /// <param name="workflow_email_id">Unique id for the Automation workflow email</param>
    /// <param name="subscriber_hash">The MD5 hash of the lowercase version of the list member’s email address.</param>
    /// </summary>
    internal async Task<MCAutomationQueue> GetSubscriberInQueue(string workflow_id, string workflow_email_id,
                                                                        string subscriber_hash)
    {
      return await emailQueue.GetSubscriberInQueue(workflow_id, workflow_email_id, subscriber_hash);
    }

    #endregion emailQueue

    #region removedSubscriber

    /// <summary>
    /// View all subscribers removed from a workflow
    /// <param name="workflow_id">Unique id for the Automation workflow</param>
    /// </summary>
    internal async Task<RemovedSubscriber> GetRemovedSubscriberList(string workflow_id)
    {
      return await removedSubscriber.GetRemovedSubscriberList(workflow_id);
    }

    #endregion removedSubscriber
  }
}