export const trialMessageHtml = (trialDaysRemaining) => `
<h4><b>Your trial has only ${trialDaysRemaining} days remaining</b></h4>
<p> Use <a href="#" data-link="/settings/billing">Billing Settings</a> to 
subscribe immediately or after the trial is over. </p>`;

export const trialOverHtml = `
<h4><b>Your trial has finished</b></h4>
<p>Please choose a subscription in <a href="#" data-link="/settings/billing">Billing Settings</a> or 
<a href="#" data-link="">Contact Us</a> if you need assistance.</p>`;

export const invalidSubscriptionHtml = `
<h4><b>Something is wrong with your subscription.</b></h4>
<p>Please head over to <a href="#" data-link="/settings/billing">Billing Settings.</a> 
and review your subscription status or <a href="#" data-link="">Contact Us</a>.</p>`;
