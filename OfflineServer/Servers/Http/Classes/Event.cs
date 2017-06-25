using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Database.Management;
using OfflineServer.Servers.Http.Responses;
using System;
using System.Collections.Generic;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Event
    {
        public static String arbitration()
        {
            String arbitrationPacket = Access.sHttp.getPostData();
            Access.CurrentSession.ActivePersona.SelectedCar.Durability -= 5;

            switch (arbitrationPacket.Substring(1, arbitrationPacket.IndexOf("ArbitrationPacket") - 1))
            {
                case "Drag":
                    {
                        DragArbitrationPacket dragArbitration = arbitrationPacket.DeserializeObject<DragArbitrationPacket>();

                        DragEventResult eventResult = new DragEventResult();
                        eventResult.accolades = getAccolades(dragArbitration);
                        eventResult.durability = Access.CurrentSession.ActivePersona.SelectedCar.Durability;
                        eventResult.entrants.Add((DragEntrantResult)dragArbitration.getEntrantResult());
                        eventResult.personaId = Access.CurrentSession.ActivePersona.Id;

                        if (EventResultManagement.eventResult != null)
                        {
                            EventResultEntity eventResultEntity = EventResultManagement.eventResult;
                            eventResultEntity.eventDurationInMilliseconds = dragArbitration.eventDurationInMilliseconds;
                            eventResultEntity.finishReason = dragArbitration.finishReason.ToString();
                            eventResultEntity.gainedExp = eventResult.accolades.finalRewards.rep;
                            eventResultEntity.gainedCash = eventResult.accolades.finalRewards.tokens;
                            eventResultEntity.perfectStart = dragArbitration.perfectStart == 1;
                            eventResultEntity.rank = dragArbitration.rank;
                            eventResultEntity.topSpeed = dragArbitration.topSpeed;

                            EventResultManagement.eventResult = eventResultEntity;
                        }

                        Access.CurrentSession.ActivePersona.currentEventId = 0;
                        Access.CurrentSession.ActivePersona.currentEventSessionId = 0;
                        return eventResult.SerializeObject();
                    }
                case "Pursuit":
                    {
                        PursuitArbitrationPacket pursuitArbitration = arbitrationPacket.DeserializeObject<PursuitArbitrationPacket>();

                        PursuitEventResult eventResult = new PursuitEventResult();
                        eventResult.accolades = getAccolades(pursuitArbitration);
                        eventResult.durability = Access.CurrentSession.ActivePersona.SelectedCar.Durability;
                        eventResult.heat = pursuitArbitration.heat;
                        eventResult.personaId = Access.CurrentSession.ActivePersona.Id;

                        if (EventResultManagement.eventResult != null)
                        {
                            EventResultEntity eventResultEntity = EventResultManagement.eventResult;
                            eventResultEntity.copsDeployed = pursuitArbitration.copsDeployed;
                            eventResultEntity.copsDisabled = pursuitArbitration.copsDisabled;
                            eventResultEntity.copsRammed = pursuitArbitration.copsRammed;
                            eventResultEntity.costToState = pursuitArbitration.costToState;
                            eventResultEntity.eventDurationInMilliseconds = pursuitArbitration.eventDurationInMilliseconds;
                            eventResultEntity.finishReason = pursuitArbitration.finishReason.ToString();
                            eventResultEntity.gainedExp = eventResult.accolades.finalRewards.rep;
                            eventResultEntity.gainedCash = eventResult.accolades.finalRewards.tokens;
                            eventResultEntity.heat = eventResult.heat;
                            eventResultEntity.infractions = pursuitArbitration.infractions;
                            eventResultEntity.rank = pursuitArbitration.rank;
                            eventResultEntity.roadBlocksDodged = pursuitArbitration.roadBlocksDodged;
                            eventResultEntity.spikeStripsDodged = pursuitArbitration.spikeStripsDodged;
                            eventResultEntity.topSpeed = pursuitArbitration.topSpeed;

                            EventResultManagement.eventResult = eventResultEntity;
                        }

                        CarManagement.car.heatLevel = pursuitArbitration.heat;
                        Access.CurrentSession.ActivePersona.currentEventId = 0;
                        Access.CurrentSession.ActivePersona.currentEventSessionId = 0;
                        return eventResult.SerializeObject();
                    }
                case "Route":
                    {
                        RouteArbitrationPacket routeArbitration = arbitrationPacket.DeserializeObject<RouteArbitrationPacket>();

                        RouteEventResult eventResult = new RouteEventResult();
                        eventResult.accolades = getAccolades(routeArbitration);
                        eventResult.durability = Access.CurrentSession.ActivePersona.SelectedCar.Durability;
                        eventResult.entrants.Add((RouteEntrantResult)routeArbitration.getEntrantResult());
                        eventResult.personaId = Access.CurrentSession.ActivePersona.Id;

                        if (EventResultManagement.eventResult != null)
                        {
                            EventResultEntity eventResultEntity = EventResultManagement.eventResult;
                            eventResultEntity.bestLapDurationInMilliseconds = routeArbitration.bestLapDurationInMilliseconds;
                            eventResultEntity.eventDurationInMilliseconds = routeArbitration.eventDurationInMilliseconds;
                            eventResultEntity.finishReason = routeArbitration.finishReason.ToString();
                            eventResultEntity.gainedExp = eventResult.accolades.finalRewards.rep;
                            eventResultEntity.gainedCash = eventResult.accolades.finalRewards.tokens;
                            eventResultEntity.perfectStart = routeArbitration.perfectStart == 1;
                            eventResultEntity.rank = routeArbitration.rank;
                            eventResultEntity.topSpeed = routeArbitration.topSpeed;

                            EventResultManagement.eventResult = eventResultEntity;
                        }

                        Access.CurrentSession.ActivePersona.currentEventId = 0;
                        Access.CurrentSession.ActivePersona.currentEventSessionId = 0;
                        return eventResult.SerializeObject();
                    }
                case "TeamEscape":
                    {
                        TeamEscapeArbitrationPacket teamEscapeArbitration = arbitrationPacket.DeserializeObject<TeamEscapeArbitrationPacket>();

                        TeamEscapeEventResult eventResult = new TeamEscapeEventResult();
                        eventResult.accolades = getAccolades(teamEscapeArbitration);
                        eventResult.durability = Access.CurrentSession.ActivePersona.SelectedCar.Durability;
                        eventResult.entrants.Add((TeamEscapeEntrantResult)teamEscapeArbitration.getEntrantResult());
                        eventResult.personaId = Access.CurrentSession.ActivePersona.Id;

                        if (EventResultManagement.eventResult != null)
                        {
                            EventResultEntity eventResultEntity = EventResultManagement.eventResult;
                            eventResultEntity.bustedCount = teamEscapeArbitration.bustedCount;
                            eventResultEntity.copsDeployed = teamEscapeArbitration.copsDeployed;
                            eventResultEntity.copsDisabled = teamEscapeArbitration.copsDisabled;
                            eventResultEntity.copsRammed = teamEscapeArbitration.copsRammed;
                            eventResultEntity.costToState = teamEscapeArbitration.costToState;
                            eventResultEntity.eventDurationInMilliseconds = teamEscapeArbitration.eventDurationInMilliseconds;
                            eventResultEntity.finishReason = teamEscapeArbitration.finishReason.ToString();
                            eventResultEntity.gainedExp = eventResult.accolades.finalRewards.rep;
                            eventResultEntity.gainedCash = eventResult.accolades.finalRewards.tokens;
                            eventResultEntity.infractions = teamEscapeArbitration.infractions;
                            eventResultEntity.perfectStart = teamEscapeArbitration.perfectStart == 1;
                            eventResultEntity.rank = teamEscapeArbitration.rank;
                            eventResultEntity.roadBlocksDodged = teamEscapeArbitration.roadBlocksDodged;
                            eventResultEntity.spikeStripsDodged = teamEscapeArbitration.spikeStripsDodged;
                            eventResultEntity.topSpeed = teamEscapeArbitration.topSpeed;

                            EventResultManagement.eventResult = eventResultEntity;
                        }

                        Access.CurrentSession.ActivePersona.currentEventId = 0;
                        Access.CurrentSession.ActivePersona.currentEventSessionId = 0;
                        return eventResult.SerializeObject();
                    }
            }
            return "";
        }

        private static Accolades getAccolades(ArbitrationPacket arbitrationPacket)
        {
            Accolades accolades = new Accolades();
            if (!finishedEvent(arbitrationPacket))
                return accolades;

            Int32 finalExp, finalCash;
            EventDefinition eventDefinition = Data.DataEx.eventDefinitions[Access.CurrentSession.ActivePersona.currentEventId];
            List<RewardPart> rewardParts = arbitrationPacket.calculateRewardParts(eventDefinition, out finalExp, out finalCash);

            accolades.finalRewards = new Reward()
            {
                rep = finalExp,
                tokens = finalCash
            };
            accolades.hasLeveledUp = Access.CurrentSession.ActivePersona.ReputationRequiredToPassTheLevel - finalExp <= 0;
            accolades.luckyDrawInfo = new LuckyDrawInfo();
            accolades.luckyDrawInfo.items.Add(
                new LuckyDrawItem()
                {
                    description = "test drop",
                    hash = 1627606782L,
                    icon = "prod_powerup_stack_onemo",
                    remainingUseCount = 1,
                    resellPrice = 0,
                    virtualItem = "onemorelap",
                    virtualItemType = VirtualItemType.powerup,
                    wasSold = false
                }
            );
            accolades.originalRewards = arbitrationPacket.calculateBaseReward(eventDefinition);
            accolades.rewardInfo = rewardParts;

            Access.CurrentSession.ActivePersona.ReputationInTotal += finalExp;
            Access.CurrentSession.ActivePersona.Cash += finalCash;

            return accolades;
        }

        private static Boolean finishedEvent(ArbitrationPacket arbitrationPacket)
        {
            switch (arbitrationPacket.finishReason)
            {
                case FinishReason.Aborted:
                case FinishReason.DidNotFinish:
                case FinishReason.FalseStart:
                case FinishReason.KnockedOut:
                case FinishReason.TimedOut:
                case FinishReason.TimeLimitExpired:
                case FinishReason.Totalled:
                case FinishReason.Unknown:
                    return false;
            }

            return true;
        }
    }
}
