using System;
using System.Collections.Generic;
using OfflineServer.Servers.Http.Responses;

namespace OfflineServer
{
    public static class AchievementDefinitions
    {
        public class AchievementDefinition
        {
            public BadgeDefinitionPacket badgeDefinition;
            public AchievementDefinitionPacket achievementDefinition;
        }

        public static readonly Dictionary<String, AchievementDefinition> achievements = new Dictionary<String, AchievementDefinition>()
        {
            {
                "ACH_AGERA_SPEEDTRAP",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 82,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000027B",
                        icon = "ACH_AGERA_SPEEDTRAP",
                        name = "GM_ACHIEVEMENT_0000010E"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "ACH_CLOCKED_AIRTIME",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 2,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000002A",
                        icon = "ACH_CLOCKED_AIRTIME",
                        name = "GM_ACHIEVEMENT_00000029"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 16,
                        badgeDefinitionId = 2,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001AE",
                        statConversion = StatConversion.FromMillisecondsToMinutes,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 72,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.5355698f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017F",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 60000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 73,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.346838146f,
                                rewardDescription = "GM_ACHIEVEMENT_00000224",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 300000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 74,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.21519959f,
                                rewardDescription = "GM_ACHIEVEMENT_00000181",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 900000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 75,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.147605032f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 1800000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 76,
                                isRare = false,
                                points = 10,
                                rank = 5,
                                rarity = 0.09555399f,
                                rewardDescription = "GM_ACHIEVEMENT_00000225",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 3600000
                            }

                        }
                    }
                }
            },

            {
                "ACH_COMPLETE_TH",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 91,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000FF",
                        icon = "ACH_COMPLETE_TH",
                        name = "GM_ACHIEVEMENT_00000002"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 84,
                        badgeDefinitionId = 91,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001EA",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 324,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.652316f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018A",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 325,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.3368932f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 326,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.183956727f,
                                rewardDescription = "GM_ACHIEVEMENT_00000265",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 100
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 327,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.08983299f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018B",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_rewardsbooster",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 328,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.04188904f,
                                rewardDescription = "GM_ACHIEVEMENT_00000193",
                                rewardType = "cardpack",
                                rewardVisualStyle = "cardpack_carprize",
                                state = AchievementState.Locked,
                                thresholdValue = 500
                            }

                        }
                    }
                }
            },

            {
                "ACH_COPSDISABLED_TE",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 17,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000005A",
                        icon = "ACH_COPSDISABLED_TE",
                        name = "GM_ACHIEVEMENT_00000059"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 13,
                        badgeDefinitionId = 17,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001BB",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 57,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.477686435f,
                                rewardDescription = "GM_ACHIEVEMENT_0000026C",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 58,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.3857053f,
                                rewardDescription = "GM_ACHIEVEMENT_00000181",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 150
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 59,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.2616354f,
                                rewardDescription = "GM_ACHIEVEMENT_00000174",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 500
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 60,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.168435469f,
                                rewardDescription = "GM_ACHIEVEMENT_00000197",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 1200
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 61,
                                isRare = false,
                                points = 10,
                                rank = 5,
                                rarity = 0.08562572f,
                                rewardDescription = "GM_ACHIEVEMENT_00000198",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_teamescape",
                                state = AchievementState.Locked,
                                thresholdValue = 3000
                            }

                        }
                    }
                }
            },

            {
                "ACH_CREW_RACER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 99,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000272",
                        icon = "ACH_CREW_RACER",
                        name = "GM_ACHIEVEMENT_0000026F"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 99,
                        badgeDefinitionId = 99,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000271",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 483,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.228734091f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024E",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 10
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 484,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.0964944959f,
                                rewardDescription = "GM_ACHIEVEMENT_00000226",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 485,
                                isRare = true,
                                points = 10,
                                rank = 3,
                                rarity = 0.0248763133f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 486,
                                isRare = true,
                                points = 10,
                                rank = 4,
                                rarity = 0.00480274251f,
                                rewardDescription = "GM_ACHIEVEMENT_00000234",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 1000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 487,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.000255997875f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 5000
                            }

                        }
                    }
                }
            },

            {
                "ACH_DODGE_ROADBLOCK_TE",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 71,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000D7",
                        icon = "ACH_DODGE_ROADBLOCK_TE",
                        name = "GM_ACHIEVEMENT_000000D6"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 14,
                        badgeDefinitionId = 71,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001DF",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 62,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.5641247f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016A",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 63,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.47365725f,
                                rewardDescription = "GM_ACHIEVEMENT_00000226",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 100
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 64,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.403096467f,
                                rewardDescription = "GM_ACHIEVEMENT_00000181",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 65,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.300357848f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 750
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 66,
                                isRare = false,
                                points = 10,
                                rank = 5,
                                rarity = 0.232869014f,
                                rewardDescription = "GM_ACHIEVEMENT_00000175",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 1500
                            }

                        }
                    }
                }
            },

            {
                "ACH_DRAG_STREAK",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 73,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000216",
                        icon = "ACH_DRAG_STREAK",
                        name = "GM_ACHIEVEMENT_00000156"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "ACH_DRIVE_MILES",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 74,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000DC",
                        icon = "ACH_DRIVE_MILES",
                        name = "GM_ACHIEVEMENT_000000DB"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 17,
                        badgeDefinitionId = 74,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000000DA",
                        statConversion = StatConversion.FromMetersToDistance,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 77,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.566779256f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024E",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 160935
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 78,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.297731072f,
                                rewardDescription = "GM_ACHIEVEMENT_00000165",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 1609347
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 79,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.109060653f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024F",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 8046723
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 80,
                                isRare = true,
                                points = 10,
                                rank = 4,
                                rarity = 0.0447439738f,
                                rewardDescription = "GM_ACHIEVEMENT_00000166",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 20116807
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 81,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.0194113161f,
                                rewardDescription = "GM_ACHIEVEMENT_0000023A",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 40233613
                            }

                        }
                    }
                }
            },

            {
                "ACH_EARN_CASH_EVENT",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 89,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F3",
                        icon = "ACH_EARN_CASH_EVENT",
                        name = "GM_ACHIEVEMENT_00000022"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 20,
                        badgeDefinitionId = 89,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001B2",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 92,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.8221538f,
                                rewardDescription = "GM_ACHIEVEMENT_00000250",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 10000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 93,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.565265536f,
                                rewardDescription = "GM_ACHIEVEMENT_00000251",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 500000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 94,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.394943476f,
                                rewardDescription = "GM_ACHIEVEMENT_00000252",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 2500000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 95,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.2095899f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018B",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_rewardsbooster",
                                state = AchievementState.Locked,
                                thresholdValue = 10000000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 96,
                                isRare = false,
                                points = 10,
                                rank = 5,
                                rarity = 0.0994106457f,
                                rewardDescription = "GM_ACHIEVEMENT_00000253",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25000000
                            }

                        }
                    }
                }
            },

            {
                "ACH_EARN_DRIVERSCORE",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_SOCIAL",
                        badgeDefinitionId = 6,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F4",
                        icon = "ACH_EARN_DRIVERSCORE",
                        name = "GM_ACHIEVEMENT_00000164"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 28,
                        badgeDefinitionId = 6,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001B3",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 132,
                                isRare = false,
                                points = 0,
                                rank = 1,
                                rarity = 0.322841138f,
                                rewardDescription = "GM_ACHIEVEMENT_00000192",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_race",
                                state = AchievementState.InProgress,
                                thresholdValue = 1000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 133,
                                isRare = false,
                                points = 0,
                                rank = 2,
                                rarity = 0.110796988f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017D",
                                rewardType = "cardpack",
                                rewardVisualStyle = "platinum",
                                state = AchievementState.Locked,
                                thresholdValue = 2000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 134,
                                isRare = true,
                                points = 0,
                                rank = 3,
                                rarity = 0.04510571f,
                                rewardDescription = "GM_ACHIEVEMENT_00000193",
                                rewardType = "cardpack",
                                rewardVisualStyle = "cardpack_carprize",
                                state = AchievementState.Locked,
                                thresholdValue = 3000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 135,
                                isRare = true,
                                points = 0,
                                rank = 4,
                                rarity = 0.0185821056f,
                                rewardDescription = "GM_ACHIEVEMENT_00000191",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 136,
                                isRare = true,
                                points = 0,
                                rank = 5,
                                rarity = 0.009833657f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017C",
                                rewardType = "car",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 5000
                            }

                        }
                    }
                }
            },

            {
                "ACH_EXPLORE_MODDER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_CUSTOMIZE",
                        badgeDefinitionId = 51,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000269",
                        icon = "ACH_EXPLORE_MODDER",
                        name = "GM_ACHIEVEMENT_00000151"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 22,
                        badgeDefinitionId = 51,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001D6",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 102,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.16277568f,
                                rewardDescription = "GM_ACHIEVEMENT_00000250",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 103,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.0555515364f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 104,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0291169751f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024B",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 105,
                                isRare = true,
                                points = 25,
                                rank = 4,
                                rarity = 0.008041672f,
                                rewardDescription = "GM_ACHIEVEMENT_00000183",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 125
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 106,
                                isRare = true,
                                points = 25,
                                rank = 5,
                                rarity = 0.00317771267f,
                                rewardDescription = "GM_ACHIEVEMENT_00000230",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            }

                        }
                    }
                }
            },

            {
                "ACH_GETAWAY_DRIVER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 95,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000021E",
                        icon = "ACH_GETAWAY_DRIVER",
                        name = "GM_ACHIEVEMENT_00000109"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 15,
                        badgeDefinitionId = 95,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000108",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 67,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.4282065f,
                                rewardDescription = "GM_ACHIEVEMENT_00000165",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 10
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 68,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.279082179f,
                                rewardDescription = "GM_ACHIEVEMENT_00000169",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 69,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.148228332f,
                                rewardDescription = "GM_ACHIEVEMENT_00000283",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 200
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 70,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.06890795f,
                                rewardDescription = "GM_ACHIEVEMENT_00000224",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 700
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 71,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.0337249376f,
                                rewardDescription = "GM_ACHIEVEMENT_00000240",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_pursuit",
                                state = AchievementState.Locked,
                                thresholdValue = 2000
                            }

                        }
                    }
                }
            },

            {
                "ACH_HOT_STREAK",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 7,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000003C",
                        icon = "ACH_HOT_STREAK",
                        name = "GM_ACHIEVEMENT_0000003B"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "ACH_I_DONT_CARRERA",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 88,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000027D",
                        icon = "ACH_I_DONT_CARRERA",
                        name = "GM_ACHIEVEMENT_000000FC"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "ACH_INCUR_COSTTOSTATE",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 1,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000013D",
                        icon = "ACH_INCUR_COSTTOSTATE",
                        name = "GM_ACHIEVEMENT_00000026"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 10,
                        badgeDefinitionId = 1,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001AD",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 46,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.536565959f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018F",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 50000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 47,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.42632547f,
                                rewardDescription = "GM_ACHIEVEMENT_00000169",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 250000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 48,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.302372426f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 1000000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 49,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.131677508f,
                                rewardDescription = "GM_ACHIEVEMENT_00000190",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 5000000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 50,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.0484503768f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016C",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25000000
                            }

                        }
                    }
                }
            },

            {
                "ACH_INSTALL_AFTERMARKETPART",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_CUSTOMIZE",
                        badgeDefinitionId = 78,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000E5",
                        icon = "ACH_INSTALL_AFTERMARKETPART",
                        name = "GM_ACHIEVEMENT_000000E4"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 18,
                        badgeDefinitionId = 78,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000000E3",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 82,
                                isRare = false,
                                points = 50,
                                rank = 1,
                                rarity = 0.611884952f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017F",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 3
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 83,
                                isRare = false,
                                points = 50,
                                rank = 2,
                                rarity = 0.393524379f,
                                rewardDescription = "GM_ACHIEVEMENT_00000227",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 15
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 84,
                                isRare = false,
                                points = 50,
                                rank = 3,
                                rarity = 0.218989477f,
                                rewardDescription = "GM_ACHIEVEMENT_00000181",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 85,
                                isRare = false,
                                points = 50,
                                rank = 4,
                                rarity = 0.08718953f,
                                rewardDescription = "GM_ACHIEVEMENT_00000183",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 200
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 86,
                                isRare = true,
                                points = 50,
                                rank = 5,
                                rarity = 0.0491571538f,
                                rewardDescription = "GM_ACHIEVEMENT_00000187",
                                rewardType = "car",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 500
                            }

                        }
                    }
                }
            },

            {
                "ACH_INSTALL_PAINTS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_CUSTOMIZE",
                        badgeDefinitionId = 31,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000080",
                        icon = "ACH_INSTALL_PAINTS",
                        name = "GM_ACHIEVEMENT_0000007F"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 26,
                        badgeDefinitionId = 31,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000007E",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 122,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.624779463f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017F",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 3
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 123,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.269281924f,
                                rewardDescription = "GM_ACHIEVEMENT_00000238",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 30
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 124,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.12761493f,
                                rewardDescription = "GM_ACHIEVEMENT_00000181",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 100
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 125,
                                isRare = true,
                                points = 10,
                                rank = 4,
                                rarity = 0.0307865255f,
                                rewardDescription = "GM_ACHIEVEMENT_0000023E",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 500
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 126,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.0187101047f,
                                rewardDescription = "GM_ACHIEVEMENT_00000228",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 1000
                            }

                        }
                    }
                }
            },

            {
                "ACH_INSTALL_PERFORMANCEPART",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_CUSTOMIZE",
                        badgeDefinitionId = 76,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000026B",
                        icon = "ACH_INSTALL_PERFORMANCEPART",
                        name = "GM_ACHIEVEMENT_000000DE"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 21,
                        badgeDefinitionId = 76,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001E3",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 97,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.454501957f,
                                rewardDescription = "GM_ACHIEVEMENT_0000025B",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 98,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.301159233f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 15
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 99,
                                isRare = false,
                                points = 25,
                                rank = 3,
                                rarity = 0.141655862f,
                                rewardDescription = "GM_ACHIEVEMENT_0000025C",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 100,
                                isRare = false,
                                points = 25,
                                rank = 4,
                                rarity = 0.07494059f,
                                rewardDescription = "GM_ACHIEVEMENT_00000183",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 100
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 101,
                                isRare = true,
                                points = 25,
                                rank = 5,
                                rarity = 0.03641848f,
                                rewardDescription = "GM_ACHIEVEMENT_000001A7",
                                rewardType = "car",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 200
                            }

                        }
                    }
                }
            },

            {
                "ACH_INSTALL_VINYLS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_CUSTOMIZE",
                        badgeDefinitionId = 56,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000017",
                        icon = "ACH_INSTALL_VINYLS",
                        name = "GM_ACHIEVEMENT_000000B4"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 29,
                        badgeDefinitionId = 56,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000000B3",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 137,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.401037335f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017F",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 10
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 138,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.183389083f,
                                rewardDescription = "GM_ACHIEVEMENT_00000233",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 100
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 139,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.08754014f,
                                rewardDescription = "GM_ACHIEVEMENT_00000234",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 500
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 140,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.06298104f,
                                rewardDescription = "GM_ACHIEVEMENT_00000181",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 1000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 141,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.0341645852f,
                                rewardDescription = "GM_ACHIEVEMENT_00000235",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 2500
                            }

                        }
                    }
                }
            },

            {
                "ACH_IS_DEVELOPER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_SOCIAL",
                        badgeDefinitionId = 59,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000B9",
                        icon = "ACH_IS_DEVELOPER",
                        name = "GM_ACHIEVEMENT_000000B8"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 31,
                        badgeDefinitionId = 59,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000049",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 143,
                                isRare = true,
                                points = 2578,
                                rank = 1,
                                rarity = 2578f,
                                rewardDescription = "GM_ACHIEVEMENT_00000199",
                                rewardType = "cardpack",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_ALFAROMEO",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 25,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001FE",
                        icon = "ACH_OWN_ALFAROMEO",
                        name = "GM_ACHIEVEMENT_00000070"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 32,
                        badgeDefinitionId = 25,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000011F",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 144,
                                isRare = true,
                                points = 25,
                                rank = 1,
                                rarity = 0.04548414f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022D",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 145,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.004819438f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 146,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.002637891f,
                                rewardDescription = "GM_ACHIEVEMENT_00000192",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_race",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_ASTONMARTIN",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 15,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F8",
                        icon = "ACH_OWN_ASTONMARTIN",
                        name = "GM_ACHIEVEMENT_00000053"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 33,
                        badgeDefinitionId = 15,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000119",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 147,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.105916336f,
                                rewardDescription = "GM_ACHIEVEMENT_00000229",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 148,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0150259612f,
                                rewardDescription = "GM_ACHIEVEMENT_00000189",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 149,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.009583225f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022A",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_AUDI",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 46,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000209",
                        icon = "ACH_OWN_AUDI",
                        name = "GM_ACHIEVEMENT_000000A0"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 36,
                        badgeDefinitionId = 46,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000128",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 160,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.318249851f,
                                rewardDescription = "GM_ACHIEVEMENT_00000228",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 161,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.05338112f,
                                rewardDescription = "GM_ACHIEVEMENT_00000196",
                                rewardType = "cardpack",
                                rewardVisualStyle = "silver",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 162,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0222606845f,
                                rewardDescription = "GM_ACHIEVEMENT_00000230",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_BENTLEY",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 27,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001FF",
                        icon = "ACH_OWN_BENTLEY",
                        name = "GM_ACHIEVEMENT_00000073"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 37,
                        badgeDefinitionId = 27,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000120",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 163,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.06964255f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022B",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 164,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.00678950874f,
                                rewardDescription = "GM_ACHIEVEMENT_00000196",
                                rewardType = "cardpack",
                                rewardVisualStyle = "silver",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 165,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0036006656f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022F",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_BMW",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 53,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000020E",
                        icon = "ACH_OWN_BMW",
                        name = "GM_ACHIEVEMENT_000000AE"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 38,
                        badgeDefinitionId = 53,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000012C",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 166,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.361580282f,
                                rewardDescription = "GM_ACHIEVEMENT_00000231",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 167,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.0939178243f,
                                rewardDescription = "GM_ACHIEVEMENT_00000186",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 168,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0295566227f,
                                rewardDescription = "GM_ACHIEVEMENT_00000232",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_CADILLAC",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 19,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001FA",
                        icon = "ACH_OWN_CADILLAC",
                        name = "GM_ACHIEVEMENT_0000005F"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 39,
                        badgeDefinitionId = 19,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000011B",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 169,
                                isRare = true,
                                points = 25,
                                rank = 1,
                                rarity = 0.03707517f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022B",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 170,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.00480830763f,
                                rewardDescription = "GM_ACHIEVEMENT_00000196",
                                rewardType = "cardpack",
                                rewardVisualStyle = "silver",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 171,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00244311f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022C",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_CAR",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 61,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000211",
                        icon = "ACH_OWN_CAR",
                        name = "GM_ACHIEVEMENT_00000018"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 19,
                        badgeDefinitionId = 61,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001DA",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 87,
                                isRare = false,
                                points = 100,
                                rank = 1,
                                rarity = 0.6875602f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022B",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 2
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 88,
                                isRare = false,
                                points = 100,
                                rank = 2,
                                rarity = 0.301409662f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 89,
                                isRare = false,
                                points = 100,
                                rank = 3,
                                rarity = 0.179749459f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 30
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 90,
                                isRare = false,
                                points = 100,
                                rank = 4,
                                rarity = 0.1354674f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017D",
                                rewardType = "cardpack",
                                rewardVisualStyle = "platinum",
                                state = AchievementState.Locked,
                                thresholdValue = 70
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 91,
                                isRare = false,
                                points = 100,
                                rank = 5,
                                rarity = 0.12025778f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018E",
                                rewardType = "car",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 150
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_CATERHAM",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 57,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000210",
                        icon = "ACH_OWN_CATERHAM",
                        name = "GM_ACHIEVEMENT_00000168"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 40,
                        badgeDefinitionId = 57,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001AA",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 172,
                                isRare = true,
                                points = 25,
                                rank = 1,
                                rarity = 0.0253382232f,
                                rewardDescription = "GM_ACHIEVEMENT_00000231",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 173,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.00129111961f,
                                rewardDescription = "GM_ACHIEVEMENT_00000236",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 174,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.000968339737f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017D",
                                rewardType = "cardpack",
                                rewardVisualStyle = "platinum",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_CHEVROLET",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 62,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000212",
                        icon = "ACH_OWN_CHEVROLET",
                        name = "GM_ACHIEVEMENT_000000BC"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 42,
                        badgeDefinitionId = 62,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000012F",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 180,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.2910473f,
                                rewardDescription = "GM_ACHIEVEMENT_0000023A",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 181,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.0622965246f,
                                rewardDescription = "GM_ACHIEVEMENT_00000186",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 182,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0263343882f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_CHRYSLER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 36,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000204",
                        icon = "ACH_OWN_CHRYSLER",
                        name = "GM_ACHIEVEMENT_00000088"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 43,
                        badgeDefinitionId = 36,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000123",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 183,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.0734936446f,
                                rewardDescription = "GM_ACHIEVEMENT_00000238",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 184,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.008108454f,
                                rewardDescription = "GM_ACHIEVEMENT_00000166",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 185,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00392344547f,
                                rewardDescription = "GM_ACHIEVEMENT_00000239",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_DODGE",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 26,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000020B",
                        icon = "ACH_OWN_DODGE",
                        name = "GM_ACHIEVEMENT_000000A6"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 44,
                        badgeDefinitionId = 26,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000023D",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 186,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.377863973f,
                                rewardDescription = "GM_ACHIEVEMENT_00000171",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 187,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.06912499f,
                                rewardDescription = "GM_ACHIEVEMENT_00000166",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 188,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.04207269f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_FORD",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 50,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000020C",
                        icon = "ACH_OWN_FORD",
                        name = "GM_ACHIEVEMENT_00000011"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 46,
                        badgeDefinitionId = 50,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000012B",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 192,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.252575278f,
                                rewardDescription = "GM_ACHIEVEMENT_00000238",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 193,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.05055401f,
                                rewardDescription = "GM_ACHIEVEMENT_0000023F",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 194,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0209695641f,
                                rewardDescription = "GM_ACHIEVEMENT_00000240",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_pursuit",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_FORDSHELBY",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 38,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000205",
                        icon = "ACH_OWN_FORDSHELBY",
                        name = "GM_ACHIEVEMENT_0000008B"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 47,
                        badgeDefinitionId = 38,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000124",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 195,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.0735493f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022B",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 196,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.00675055245f,
                                rewardDescription = "GM_ACHIEVEMENT_00000184",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 197,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.002637891f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_HUMMER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 24,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001FD",
                        icon = "ACH_OWN_HUMMER",
                        name = "GM_ACHIEVEMENT_0000006D"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 48,
                        badgeDefinitionId = 24,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000011E",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 198,
                                isRare = true,
                                points = 25,
                                rank = 1,
                                rarity = 0.0263399538f,
                                rewardDescription = "GM_ACHIEVEMENT_00000242",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 199,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.00184763677f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016C",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 200,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00104625209f,
                                rewardDescription = "GM_ACHIEVEMENT_00000243",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_INFINITI",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 44,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000208",
                        icon = "ACH_OWN_INFINITI",
                        name = "GM_ACHIEVEMENT_0000009A"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 49,
                        badgeDefinitionId = 44,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000127",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 201,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.06874656f,
                                rewardDescription = "GM_ACHIEVEMENT_00000238",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 202,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0122545063f,
                                rewardDescription = "GM_ACHIEVEMENT_00000196",
                                rewardType = "cardpack",
                                rewardVisualStyle = "silver",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 203,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00695646368f,
                                rewardDescription = "GM_ACHIEVEMENT_00000244",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_JAGUAR",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 77,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000218",
                        icon = "ACH_OWN_JAGUAR",
                        name = "GM_ACHIEVEMENT_000000E1"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 50,
                        badgeDefinitionId = 77,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000133",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 204,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.0670881346f,
                                rewardDescription = "GM_ACHIEVEMENT_00000245",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 205,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.008219757f,
                                rewardDescription = "GM_ACHIEVEMENT_00000246",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 206,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.004429876f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_JEEP",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 33,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000201",
                        icon = "ACH_OWN_JEEP",
                        name = "GM_ACHIEVEMENT_00000167"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 51,
                        badgeDefinitionId = 33,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001A8",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 207,
                                isRare = true,
                                points = 25,
                                rank = 1,
                                rarity = 0.0179254152f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022B",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 208,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.00140798825f,
                                rewardDescription = "GM_ACHIEVEMENT_00000181",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 209,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00105738244f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022C",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_KOENIGSEGG",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 93,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000021D",
                        icon = "ACH_OWN_KOENIGSEGG",
                        name = "GM_ACHIEVEMENT_00000104"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 53,
                        badgeDefinitionId = 93,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000139",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 215,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.175330713f,
                                rewardDescription = "GM_ACHIEVEMENT_00000229",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 216,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.008086193f,
                                rewardDescription = "GM_ACHIEVEMENT_00000236",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 217,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00180868059f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017D",
                                rewardType = "cardpack",
                                rewardVisualStyle = "platinum",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_LAMBORGHINI",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 80,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000219",
                        icon = "ACH_OWN_LAMBORGHINI",
                        name = "GM_ACHIEVEMENT_0000001D"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 55,
                        badgeDefinitionId = 80,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000134",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 223,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.314203978f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022D",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 224,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.071812965f,
                                rewardDescription = "GM_ACHIEVEMENT_00000236",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 225,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0247149244f,
                                rewardDescription = "GM_ACHIEVEMENT_00000249",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_LANCIA",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 20,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001FB",
                        icon = "ACH_OWN_LANCIA",
                        name = "GM_ACHIEVEMENT_00000062"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 56,
                        badgeDefinitionId = 20,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000011C",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 226,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.09032829f,
                                rewardDescription = "GM_ACHIEVEMENT_00000247",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 227,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0113418186f,
                                rewardDescription = "GM_ACHIEVEMENT_00000166",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 228,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00744063361f,
                                rewardDescription = "GM_ACHIEVEMENT_00000248",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_LEXUS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 3,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F0",
                        icon = "ACH_OWN_LEXUS",
                        name = "GM_ACHIEVEMENT_0000002E"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 57,
                        badgeDefinitionId = 3,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000114",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 229,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.23157233f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022B",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 230,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0345207565f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024A",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 231,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0195281841f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_LOTUS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 68,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000215",
                        icon = "ACH_OWN_LOTUS",
                        name = "GM_ACHIEVEMENT_000000CD"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 58,
                        badgeDefinitionId = 68,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000132",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 232,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.149419278f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022B",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 233,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.02539944f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024D",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 234,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.01382945f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_MARUSSIA",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 87,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000021C",
                        icon = "ACH_OWN_MARUSSIA",
                        name = "GM_ACHIEVEMENT_000000F9"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 59,
                        badgeDefinitionId = 87,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000137",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 235,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.0509324446f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022B",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 236,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0029884968f,
                                rewardDescription = "GM_ACHIEVEMENT_00000229",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 237,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00155268272f,
                                rewardDescription = "GM_ACHIEVEMENT_0000023A",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_MAZDA",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 29,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000200",
                        icon = "ACH_OWN_MAZDA",
                        name = "GM_ACHIEVEMENT_00000079"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 60,
                        badgeDefinitionId = 29,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000121",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 238,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.5281347f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018D",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 239,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.204430982f,
                                rewardDescription = "GM_ACHIEVEMENT_00000166",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 240,
                                isRare = false,
                                points = 25,
                                rank = 3,
                                rarity = 0.167177737f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024C",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_MCLAREN",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 5,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F2",
                        icon = "ACH_OWN_MCLAREN",
                        name = "GM_ACHIEVEMENT_00000033"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 61,
                        badgeDefinitionId = 5,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000115",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 241,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.108648829f,
                                rewardDescription = "GM_ACHIEVEMENT_00000231",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 242,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0049975235f,
                                rewardDescription = "GM_ACHIEVEMENT_00000236",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 243,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0017697243f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017D",
                                rewardType = "cardpack",
                                rewardVisualStyle = "platinum",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_MERCEDES-BENZ",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 9,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F5",
                        icon = "ACH_OWN_MERCEDES-BENZ",
                        name = "GM_ACHIEVEMENT_00000041"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 62,
                        badgeDefinitionId = 9,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000040",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 244,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.06889125f,
                                rewardDescription = "GM_ACHIEVEMENT_00000254",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 245,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.00721802656f,
                                rewardDescription = "GM_ACHIEVEMENT_00000189",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 246,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00382327242f,
                                rewardDescription = "GM_ACHIEVEMENT_00000192",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_race",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_MITSUBISHI",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 14,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F7",
                        icon = "ACH_OWN_MITSUBISHI",
                        name = "GM_ACHIEVEMENT_00000050"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 63,
                        badgeDefinitionId = 14,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000118",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 247,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.3413342f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018D",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 248,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.0532698147f,
                                rewardDescription = "GM_ACHIEVEMENT_00000166",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 249,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.028888803f,
                                rewardDescription = "GM_ACHIEVEMENT_00000255",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_NISSAN",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 43,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000207",
                        icon = "ACH_OWN_NISSAN",
                        name = "GM_ACHIEVEMENT_00000097"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 65,
                        badgeDefinitionId = 43,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000126",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 255,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.5791896f,
                                rewardDescription = "GM_ACHIEVEMENT_00000242",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 256,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.110374033f,
                                rewardDescription = "GM_ACHIEVEMENT_00000184",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 257,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0428072959f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_PAGANI",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 21,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001FC",
                        icon = "ACH_OWN_PAGANI",
                        name = "GM_ACHIEVEMENT_00000065"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 68,
                        badgeDefinitionId = 21,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000011D",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 268,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.119745784f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022D",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 269,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.007273678f,
                                rewardDescription = "GM_ACHIEVEMENT_00000236",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 270,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00119094655f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017D",
                                rewardType = "cardpack",
                                rewardVisualStyle = "platinum",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_PLYMOUTH",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 47,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000020A",
                        icon = "ACH_OWN_PLYMOUTH",
                        name = "GM_ACHIEVEMENT_000000A3"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 69,
                        badgeDefinitionId = 47,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000129",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 271,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.07995481f,
                                rewardDescription = "GM_ACHIEVEMENT_00000245",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 272,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0153876981f,
                                rewardDescription = "GM_ACHIEVEMENT_00000196",
                                rewardType = "cardpack",
                                rewardVisualStyle = "silver",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 273,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.009599919f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_PONTIAC",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 63,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000213",
                        icon = "ACH_OWN_PONTIAC",
                        name = "GM_ACHIEVEMENT_000000BF"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 70,
                        badgeDefinitionId = 63,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000130",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 274,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.2188726f,
                                rewardDescription = "GM_ACHIEVEMENT_00000259",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 275,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.03681917f,
                                rewardDescription = "GM_ACHIEVEMENT_00000181",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 276,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.02279494f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_PORSCHE",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 55,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000020F",
                        icon = "ACH_OWN_PORSCHE",
                        name = "GM_ACHIEVEMENT_000000B1"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 72,
                        badgeDefinitionId = 55,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000012D",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 282,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.3110374f,
                                rewardDescription = "GM_ACHIEVEMENT_00000257",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 283,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.08112906f,
                                rewardDescription = "GM_ACHIEVEMENT_00000184",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 284,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0373645574f,
                                rewardDescription = "GM_ACHIEVEMENT_00000258",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_RENAULTSPORT",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 35,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000203",
                        icon = "ACH_OWN_RENAULTSPORT",
                        name = "GM_ACHIEVEMENT_00000085"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 73,
                        badgeDefinitionId = 35,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000122",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 285,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.102482624f,
                                rewardDescription = "GM_ACHIEVEMENT_00000238",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 286,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0187323652f,
                                rewardDescription = "GM_ACHIEVEMENT_00000256",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 287,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.01318389f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_SCION",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 64,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000214",
                        icon = "ACH_OWN_SCION",
                        name = "GM_ACHIEVEMENT_000000C2"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 74,
                        badgeDefinitionId = 64,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000131",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 288,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.08112349f,
                                rewardDescription = "GM_ACHIEVEMENT_00000238",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 289,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.013139369f,
                                rewardDescription = "GM_ACHIEVEMENT_00000196",
                                rewardType = "cardpack",
                                rewardVisualStyle = "silver",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 290,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.008002716f,
                                rewardDescription = "GM_ACHIEVEMENT_0000025A",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_SEAT",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 58,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000B7",
                        icon = "ACH_OWN_SEAT",
                        name = "GM_ACHIEVEMENT_000000B6"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "ACH_OWN_SHELBY",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 18,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F9",
                        icon = "ACH_OWN_SHELBY",
                        name = "GM_ACHIEVEMENT_0000005C"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 76,
                        badgeDefinitionId = 18,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000011A",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 294,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.05449972f,
                                rewardDescription = "GM_ACHIEVEMENT_00000261",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 295,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0102232192f,
                                rewardDescription = "GM_ACHIEVEMENT_00000196",
                                rewardType = "cardpack",
                                rewardVisualStyle = "silver",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 296,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.00769663136f,
                                rewardDescription = "GM_ACHIEVEMENT_00000262",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_SUBARU",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 11,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F6",
                        icon = "ACH_OWN_SUBARU",
                        name = "GM_ACHIEVEMENT_00000047"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 77,
                        badgeDefinitionId = 11,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000117",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 297,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.12348558f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024A",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 298,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.01871567f,
                                rewardDescription = "GM_ACHIEVEMENT_00000184",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 299,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0117814671f,
                                rewardDescription = "GM_ACHIEVEMENT_00000260",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_TOYOTA",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 81,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000021A",
                        icon = "ACH_OWN_TOYOTA",
                        name = "GM_ACHIEVEMENT_000000EC"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 78,
                        badgeDefinitionId = 81,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000135",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 300,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.229429737f,
                                rewardDescription = "GM_ACHIEVEMENT_00000228",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 301,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.04313564f,
                                rewardDescription = "GM_ACHIEVEMENT_00000166",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 302,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0225778986f,
                                rewardDescription = "GM_ACHIEVEMENT_00000264",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_VAUXHALL",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 40,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000206",
                        icon = "ACH_OWN_VAUXHALL",
                        name = "GM_ACHIEVEMENT_00000091"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 79,
                        badgeDefinitionId = 40,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000125",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 303,
                                isRare = true,
                                points = 25,
                                rank = 1,
                                rarity = 0f,
                                rewardDescription = "GM_ACHIEVEMENT_0000023C",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 304,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0f,
                                rewardDescription = "GM_ACHIEVEMENT_00000196",
                                rewardType = "cardpack",
                                rewardVisualStyle = "silver",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 305,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_OWN_VOLKSWAGEN",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COLLECT",
                        badgeDefinitionId = 85,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000021B",
                        icon = "ACH_OWN_VOLKSWAGEN",
                        name = "GM_ACHIEVEMENT_000000F3"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 80,
                        badgeDefinitionId = 85,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000136",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 306,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.373589933f,
                                rewardDescription = "GM_ACHIEVEMENT_00000227",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 307,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0490180254f,
                                rewardDescription = "GM_ACHIEVEMENT_00000181",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 4
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 308,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.02769229f,
                                rewardDescription = "GM_ACHIEVEMENT_00000266",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_PARTICIPATE_OPENBETA",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_SOCIAL",
                        badgeDefinitionId = 84,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000F1",
                        icon = "ACH_PARTICIPATE_OPENBETA",
                        name = "GM_ACHIEVEMENT_000000F0"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 30,
                        badgeDefinitionId = 84,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000049",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 142,
                                isRare = true,
                                points = 0,
                                rank = 1,
                                rarity = 0.012894501f,
                                rewardDescription = "GM_ACHIEVEMENT_0000025D",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            }

                        }
                    }
                }
            },

            {
                "ACH_PLAY_EVENTS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 94,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000107",
                        icon = "ACH_PLAY_EVENTS",
                        name = "GM_ACHIEVEMENT_00000020"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 82,
                        badgeDefinitionId = 94,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000106",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 314,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.476117074f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017F",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 10
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 315,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.327794135f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 316,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.163337767f,
                                rewardDescription = "GM_ACHIEVEMENT_000001A4",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 317,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.0610109679f,
                                rewardDescription = "GM_ACHIEVEMENT_00000183",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 1000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 318,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.00762428436f,
                                rewardDescription = "GM_ACHIEVEMENT_000001A5",
                                rewardType = "car",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 5000
                            }

                        }
                    }
                }
            },

            {
                "ACH_PURSUIT",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 4,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000001F1",
                        icon = "ACH_PURSUIT",
                        name = "GM_ACHIEVEMENT_00000005"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 12,
                        badgeDefinitionId = 4,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000030",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 52,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.3151445f,
                                rewardDescription = "GM_ACHIEVEMENT_0000019A",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 10
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 53,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.149018586f,
                                rewardDescription = "GM_ACHIEVEMENT_00000171",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 54,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.07233609f,
                                rewardDescription = "GM_ACHIEVEMENT_0000019B",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 200
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 55,
                                isRare = true,
                                points = 10,
                                rank = 4,
                                rarity = 0.0409151353f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 750
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 56,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.0228338968f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016C",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 2000
                            }

                        }
                    }
                }
            },

            {
                "ACH_PURSUIT_MODDER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_CUSTOMIZE",
                        badgeDefinitionId = 42,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000268",
                        icon = "ACH_PURSUIT_MODDER",
                        name = "GM_ACHIEVEMENT_0000014B"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 23,
                        badgeDefinitionId = 42,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001CE",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 107,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.167483822f,
                                rewardDescription = "GM_ACHIEVEMENT_00000287",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 108,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.0564363971f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022B",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 109,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0302800946f,
                                rewardDescription = "GM_ACHIEVEMENT_00000190",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 110,
                                isRare = true,
                                points = 25,
                                rank = 4,
                                rarity = 0.008642711f,
                                rewardDescription = "GM_ACHIEVEMENT_00000183",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 125
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 111,
                                isRare = true,
                                points = 25,
                                rank = 5,
                                rarity = 0.0032277992f,
                                rewardDescription = "GM_ACHIEVEMENT_00000263",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            }

                        }
                    }
                }
            },

            {
                "ACH_RACE_MODDER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_CUSTOMIZE",
                        badgeDefinitionId = 34,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000267",
                        icon = "ACH_RACE_MODDER",
                        name = "GM_ACHIEVEMENT_00000148"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 24,
                        badgeDefinitionId = 34,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000202",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 112,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.216891408f,
                                rewardDescription = "GM_ACHIEVEMENT_00000259",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 113,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.0740000755f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024F",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 114,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0405088775f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 115,
                                isRare = true,
                                points = 25,
                                rank = 4,
                                rarity = 0.014480575f,
                                rewardDescription = "GM_ACHIEVEMENT_00000183",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 125
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 116,
                                isRare = true,
                                points = 25,
                                rank = 5,
                                rarity = 0.00596586335f,
                                rewardDescription = "GM_ACHIEVEMENT_00000232",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            }

                        }
                    }
                }
            },

            {
                "ACH_RAPTOR",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 69,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000274",
                        icon = "ACH_RAPTOR",
                        name = "GM_ACHIEVEMENT_000000D0"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "ACH_REACH_DRIVERAGE",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_SOCIAL",
                        badgeDefinitionId = 72,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000222",
                        icon = "ACH_REACH_DRIVERAGE",
                        name = "GM_ACHIEVEMENT_000000D8"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "ACH_REACH_DRIVERLEVEL",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_SOCIAL",
                        badgeDefinitionId = 13,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000004E",
                        icon = "ACH_REACH_DRIVERLEVEL",
                        name = "GM_ACHIEVEMENT_0000004D"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 27,
                        badgeDefinitionId = 13,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001B8",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 127,
                                isRare = false,
                                points = 50,
                                rank = 1,
                                rarity = 0.7331779f,
                                rewardDescription = "GM_ACHIEVEMENT_00000241",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 128,
                                isRare = false,
                                points = 50,
                                rank = 2,
                                rarity = 0.5702631f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 15
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 129,
                                isRare = false,
                                points = 50,
                                rank = 3,
                                rarity = 0.3999132f,
                                rewardDescription = "GM_ACHIEVEMENT_00000166",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 30
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 130,
                                isRare = false,
                                points = 50,
                                rank = 4,
                                rarity = 0.2574615f,
                                rewardDescription = "GM_ACHIEVEMENT_0000024B",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 45
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 131,
                                isRare = false,
                                points = 50,
                                rank = 5,
                                rarity = 0.140487179f,
                                rewardDescription = "GM_ACHIEVEMENT_00000194",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 60
                            }

                        }
                    }
                }
            },

            {
                "ACH_SOLO_RACER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 100,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000276",
                        icon = "ACH_SOLO_RACER",
                        name = "GM_ACHIEVEMENT_00000270"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 100,
                        badgeDefinitionId = 100,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000275",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 488,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.3373217f,
                                rewardDescription = "GM_ACHIEVEMENT_00000250",
                                rewardType = "powerup",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 10
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 489,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.137582153f,
                                rewardDescription = "GM_ACHIEVEMENT_00000238",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 490,
                                isRare = true,
                                points = 10,
                                rank = 3,
                                rarity = 0.0360400453f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 491,
                                isRare = true,
                                points = 10,
                                rank = 4,
                                rarity = 0.008392278f,
                                rewardDescription = "GM_ACHIEVEMENT_00000166",
                                rewardType = "cardpack",
                                rewardVisualStyle = "mystery",
                                state = AchievementState.Locked,
                                thresholdValue = 1000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 492,
                                isRare = true,
                                points = 10,
                                rank = 5,
                                rarity = 0.000968339737f,
                                rewardDescription = "GM_ACHIEVEMENT_00000252",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 5000
                            }

                        }
                    }
                }
            },

            {
                "ACH_ULTRA_ULTRA",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_CUSTOMIZE",
                        badgeDefinitionId = 79,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000027A",
                        icon = "ACH_ULTRA_ULTRA",
                        name = "GM_ACHIEVEMENT_000000E7"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "ACH_UNTOUCHABLE",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 67,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000278",
                        icon = "ACH_UNTOUCHABLE",
                        name = "GM_ACHIEVEMENT_000000CA"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "ACH_USE_NOS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 96,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000026E",
                        icon = "ACH_USE_NOS",
                        name = "GM_ACHIEVEMENT_0000010C"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 81,
                        badgeDefinitionId = 96,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000026D",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 309,
                                isRare = false,
                                points = 10,
                                rank = 1,
                                rarity = 0.8778946f,
                                rewardDescription = "GM_ACHIEVEMENT_000001A6",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 1
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 310,
                                isRare = false,
                                points = 10,
                                rank = 2,
                                rarity = 0.599396765f,
                                rewardDescription = "GM_ACHIEVEMENT_00000238",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 311,
                                isRare = false,
                                points = 10,
                                rank = 3,
                                rarity = 0.407270342f,
                                rewardDescription = "GM_ACHIEVEMENT_00000196",
                                rewardType = "cardpack",
                                rewardVisualStyle = "silver",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 312,
                                isRare = false,
                                points = 10,
                                rank = 4,
                                rarity = 0.214286909f,
                                rewardDescription = "GM_ACHIEVEMENT_0000025E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 1000
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 313,
                                isRare = false,
                                points = 10,
                                rank = 5,
                                rarity = 0.11200463f,
                                rewardDescription = "GM_ACHIEVEMENT_0000025F",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 2500
                            }

                        }
                    }
                }
            },

            {
                "ACH_WIN_DRAG",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 49,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000014F",
                        icon = "ACH_WIN_DRAG",
                        name = "GM_ACHIEVEMENT_0000014E"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 8,
                        badgeDefinitionId = 49,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000014D",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 36,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.195009157f,
                                rewardDescription = "GM_ACHIEVEMENT_00000179",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 10
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 37,
                                isRare = false,
                                points = 25,
                                rank = 2,
                                rarity = 0.08697249f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 38,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0244923178f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017A",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 200
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 39,
                                isRare = true,
                                points = 25,
                                rank = 4,
                                rarity = 0.005236826f,
                                rewardDescription = "GM_ACHIEVEMENT_00000183",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 750
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 40,
                                isRare = true,
                                points = 25,
                                rank = 5,
                                rarity = 0.00111859932f,
                                rewardDescription = "GM_ACHIEVEMENT_00000192",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_race",
                                state = AchievementState.Locked,
                                thresholdValue = 2500
                            }

                        }
                    }
                }
            },

            {
                "ACH_WIN_RACES_ACLASS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 30,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000007D",
                        icon = "ACH_WIN_RACES_ACLASS",
                        name = "GM_ACHIEVEMENT_0000007C"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 1,
                        badgeDefinitionId = 30,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001C6",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 1,
                                isRare = false,
                                points = 50,
                                rank = 1,
                                rarity = 0.08308244f,
                                rewardDescription = "GM_ACHIEVEMENT_00000226",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 2,
                                isRare = true,
                                points = 50,
                                rank = 2,
                                rarity = 0.04152174f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 3,
                                isRare = true,
                                points = 50,
                                rank = 3,
                                rarity = 0.0308811329f,
                                rewardDescription = "GM_ACHIEVEMENT_00000186",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 4,
                                isRare = true,
                                points = 50,
                                rank = 4,
                                rarity = 0.0194224473f,
                                rewardDescription = "GM_ACHIEVEMENT_00000183",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 125
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 5,
                                isRare = true,
                                points = 50,
                                rank = 5,
                                rarity = 0.0128889363f,
                                rewardDescription = "GM_ACHIEVEMENT_0000017D",
                                rewardType = "cardpack",
                                rewardVisualStyle = "platinum",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            }

                        }
                    }
                }
            },

            {
                "ACH_WIN_RACES_BCLASS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 10,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000045",
                        icon = "ACH_WIN_RACES_BCLASS",
                        name = "GM_ACHIEVEMENT_00000044"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 2,
                        badgeDefinitionId = 10,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001B6",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 6,
                                isRare = false,
                                points = 50,
                                rank = 1,
                                rarity = 0.0892709047f,
                                rewardDescription = "GM_ACHIEVEMENT_00000228",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 7,
                                isRare = true,
                                points = 50,
                                rank = 2,
                                rarity = 0.0441874564f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 8,
                                isRare = true,
                                points = 50,
                                rank = 3,
                                rarity = 0.031916257f,
                                rewardDescription = "GM_ACHIEVEMENT_00000186",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 9,
                                isRare = true,
                                points = 50,
                                rank = 4,
                                rarity = 0.018893756f,
                                rewardDescription = "GM_ACHIEVEMENT_00000183",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 125
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 10,
                                isRare = true,
                                points = 50,
                                rank = 5,
                                rarity = 0.0126385028f,
                                rewardDescription = "GM_ACHIEVEMENT_00000192",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_race",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            }

                        }
                    }
                }
            },

            {
                "ACH_WIN_RACES_CCLASS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 32,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000083",
                        icon = "ACH_WIN_RACES_CCLASS",
                        name = "GM_ACHIEVEMENT_00000082"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 3,
                        badgeDefinitionId = 32,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001C8",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 11,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.06640362f,
                                rewardDescription = "GM_ACHIEVEMENT_00000165",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 12,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.0300741829f,
                                rewardDescription = "GM_ACHIEVEMENT_00000237",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 13,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0222551189f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 14,
                                isRare = true,
                                points = 25,
                                rank = 4,
                                rarity = 0.0127665019f,
                                rewardDescription = "GM_ACHIEVEMENT_00000186",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 125
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 15,
                                isRare = true,
                                points = 25,
                                rank = 5,
                                rarity = 0.008614885f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            }

                        }
                    }
                }
            },

            {
                "ACH_WIN_RACES_DCLASS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 41,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000095",
                        icon = "ACH_WIN_RACES_DCLASS",
                        name = "GM_ACHIEVEMENT_00000094"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 4,
                        badgeDefinitionId = 41,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001CD",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 16,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.07290374f,
                                rewardDescription = "GM_ACHIEVEMENT_00000165",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 17,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.03215556f,
                                rewardDescription = "GM_ACHIEVEMENT_0000023C",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 18,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0235685f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 19,
                                isRare = true,
                                points = 25,
                                rank = 4,
                                rarity = 0.0133174537f,
                                rewardDescription = "GM_ACHIEVEMENT_00000186",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 125
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 20,
                                isRare = true,
                                points = 25,
                                rank = 5,
                                rarity = 0.009132446f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            }

                        }
                    }
                }
            },

            {
                "ACH_WIN_RACES_ECLASS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 92,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000102",
                        icon = "ACH_WIN_RACES_ECLASS",
                        name = "GM_ACHIEVEMENT_00000101"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 5,
                        badgeDefinitionId = 92,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001EB",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 21,
                                isRare = false,
                                points = 25,
                                rank = 1,
                                rarity = 0.05246843f,
                                rewardDescription = "GM_ACHIEVEMENT_00000165",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 22,
                                isRare = true,
                                points = 25,
                                rank = 2,
                                rarity = 0.02330137f,
                                rewardDescription = "GM_ACHIEVEMENT_00000241",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 23,
                                isRare = true,
                                points = 25,
                                rank = 3,
                                rarity = 0.0167400334f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 24,
                                isRare = true,
                                points = 25,
                                rank = 4,
                                rarity = 0.008787405f,
                                rewardDescription = "GM_ACHIEVEMENT_00000186",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 125
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 25,
                                isRare = true,
                                points = 25,
                                rank = 5,
                                rarity = 0.005860125f,
                                rewardDescription = "GM_ACHIEVEMENT_00000185",
                                rewardType = "cardpack",
                                rewardVisualStyle = "gold",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            }

                        }
                    }
                }
            },

            {
                "ACH_WIN_RACES_SCLASS",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 28,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000077",
                        icon = "ACH_WIN_RACES_SCLASS",
                        name = "GM_ACHIEVEMENT_00000076"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 6,
                        badgeDefinitionId = 28,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_000001C4",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 26,
                                isRare = false,
                                points = 50,
                                rank = 1,
                                rarity = 0.06685996f,
                                rewardDescription = "GM_ACHIEVEMENT_00000245",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 5
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 27,
                                isRare = true,
                                points = 50,
                                rank = 2,
                                rarity = 0.0343927555f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 25
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 28,
                                isRare = true,
                                points = 50,
                                rank = 3,
                                rarity = 0.0258001331f,
                                rewardDescription = "GM_ACHIEVEMENT_0000022E",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 50
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 29,
                                isRare = true,
                                points = 50,
                                rank = 4,
                                rarity = 0.0159943011f,
                                rewardDescription = "GM_ACHIEVEMENT_00000263",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 125
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 30,
                                isRare = true,
                                points = 50,
                                rank = 5,
                                rarity = 0.0117814671f,
                                rewardDescription = "GM_ACHIEVEMENT_00000193",
                                rewardType = "cardpack",
                                rewardVisualStyle = "cardpack_carprize",
                                state = AchievementState.Locked,
                                thresholdValue = 250
                            }

                        }
                    }
                }
            },

            {
                "ACH_WINSTREAK_TH",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 22,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000069",
                        icon = "ACH_WINSTREAK_TH",
                        name = "GM_ACHIEVEMENT_00000068"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 86,
                        badgeDefinitionId = 22,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_00000067",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 330,
                                isRare = false,
                                points = 50,
                                rank = 1,
                                rarity = 0.508211434f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018A",
                                rewardType = "skillmod",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 3
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 331,
                                isRare = false,
                                points = 50,
                                rank = 2,
                                rarity = 0.407415032f,
                                rewardDescription = "GM_ACHIEVEMENT_0000016B",
                                rewardType = "cash",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 7
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 332,
                                isRare = false,
                                points = 50,
                                rank = 3,
                                rarity = 0.243053272f,
                                rewardDescription = "GM_ACHIEVEMENT_0000023B",
                                rewardType = "performance",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 30
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 333,
                                isRare = false,
                                points = 50,
                                rank = 4,
                                rarity = 0.126329377f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018B",
                                rewardType = "cardpack",
                                rewardVisualStyle = "skillmods_gold_rewardsbooster",
                                state = AchievementState.Locked,
                                thresholdValue = 90
                            },

                            new AchievementRankPacket() {
                                achievementRankId = 334,
                                isRare = false,
                                points = 50,
                                rank = 5,
                                rarity = 0.07568633f,
                                rewardDescription = "GM_ACHIEVEMENT_0000018C",
                                rewardType = "car",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.Locked,
                                thresholdValue = 180
                            }

                        }
                    }
                }
            },

            {
                "ACH_XKR_SPEED_HUNTER",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 12,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000004B",
                        icon = "ACH_XKR_SPEED_HUNTER",
                        name = "GM_ACHIEVEMENT_0000004A"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                    {
                        achievementDefinitionId = 11,
                        badgeDefinitionId = 12,
                        canProgress = true,
                        currentValue = 0,
                        isVisible = true,
                        progressText = "GM_ACHIEVEMENT_0000004B",
                        statConversion = StatConversion.None,

                        achievementRanks = new List<AchievementRankPacket>()
                        {
                            new AchievementRankPacket() {
                                achievementRankId = 800,
                                isRare = true,
                                points = 25,
                                rank = 1,
                                rarity = 0.02769229f,
                                rewardDescription = "GM_ACHIEVEMENT_0000004A",
                                rewardType = "aftermarket",
                                rewardVisualStyle = "achievements_rewards",
                                state = AchievementState.InProgress,
                                thresholdValue = 10
                            }

                        }
                    }
                }
            },

            {
                "ACH_ZR1_CLASS_KING",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG_COMPETE",
                        badgeDefinitionId = 8,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000003F",
                        icon = "ACH_ZR1_CLASS_KING",
                        name = "GM_ACHIEVEMENT_0000003E"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "badge10",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 54,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000014",
                        icon = "badge10",
                        name = "GM_ACHIEVEMENT_00000013"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "badge19",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 39,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000008F",
                        icon = "badge19",
                        name = "GM_ACHIEVEMENT_0000008E"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_00000056",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 16,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000057",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_00000056"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_0000006A",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 23,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000140",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_0000006A"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_00000145",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 37,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000146",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_00000145"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_0000009D",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 45,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000009E",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_0000009D"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_000000AB",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 52,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000AC",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_000000AB"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_00000154",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 60,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000155",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_00000154"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_000000C5",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 65,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000C6",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_000000C5"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_000000C8",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 66,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000C9",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_000000C8"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_000000D3",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 70,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000D4",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_000000D3"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_00000159",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 75,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000015A",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_00000159"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_000000EE",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 83,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000EF",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_000000EE"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_000000F6",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 86,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_000000F7",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_000000F6"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_0000015C",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 90,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_0000015D",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_0000015C"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_0000015F",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 97,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000160",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_0000015F"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            },

            {
                "GM_ACHIEVEMENT_00000162",
                new AchievementDefinition() {
                    badgeDefinition = new BadgeDefinitionPacket() {
                        background = "ACH_ICON_BG",
                        badgeDefinitionId = 98,
                        border = "ACH_ICON_FRAME",
                        description = "GM_ACHIEVEMENT_00000163",
                        icon = "empty",
                        name = "GM_ACHIEVEMENT_00000162"
                    },
                    achievementDefinition = new AchievementDefinitionPacket()
                }
            }
        };
    }
}