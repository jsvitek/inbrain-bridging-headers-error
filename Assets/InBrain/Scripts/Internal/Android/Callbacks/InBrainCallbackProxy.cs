﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace InBrain
{
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public class InBrainCallbackProxy : AndroidJavaProxy
	{
		readonly Action<InBrainRewardsViewDismissedResult> _onRewardsViewDismissed;
		readonly Action<List<InBrainReward>> _onRewardsReceived;
		readonly bool _confirmRewardsAutomatically;

		public InBrainCallbackProxy(Action<InBrainRewardsViewDismissedResult> onRewardsViewDismissed, Action<List<InBrainReward>> onRewardsReceived, 
			bool confirmRewardsAutomatically)
			: base(Constants.InBrainCallbackJavaCLass)
		{
			_onRewardsViewDismissed = onRewardsViewDismissed;
			_onRewardsReceived = onRewardsReceived;
			_confirmRewardsAutomatically = confirmRewardsAutomatically;
		}

		public void surveysClosed(bool byWebView, AndroidJavaObject rewards /* List<InBrainSurveyReward> rewards */)
		{
			InBrainSceneHelper.Queue(() => _onRewardsViewDismissed(new InBrainRewardsViewDismissedResult(byWebView, rewards)));
		}

		public void surveysClosed()
		{
			// Deprecated
		}

		public void surveysClosedFromPage()
		{
			// Deprecated
		}

		public bool didReceiveInBrainRewards(AndroidJavaObject rewardsList /* List<Reward> rewards */)
		{
			InBrainSceneHelper.Queue(() => _onRewardsReceived(new InBrainGetRewardsResult(rewardsList).rewards));
			return _confirmRewardsAutomatically;
		}
	}
}