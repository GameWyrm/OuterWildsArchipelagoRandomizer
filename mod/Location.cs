﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArchipelagoRandomizer;

public enum Location
{
    // Default Locations
    SPACESHIP, // no longer in use; keeping for backwards compatibility with existing mod save files
    SS,
    ET_DRUM,
    ET_HEL,
    ET_SC_SHRINE,
    ET_QML,
    ET_FOSSIL,
    ET_LAKEBED_CAVE,
    ET_COLEUS_CAVE,
    ET_SHARD_SIGNAL,
    ET_EP2_SIGNAL,
    AT_ATP,
    TH_GM,
    TH_ZERO_G,
    TH_HAL,
    TH_HORNFELS,
    TH_SEED_CRATER,
    TH_MINES,
    TH_MS_SIGNAL,
    TH_GS_SIGNAL,
    TH_GALENA_SIGNAL,
    TH_TEPHRA_SIGNAL,
    AR_WHISTLE,
    AR_ESL,
    BH_BANJO,
    BH_OBSERVATORY,
    BH_OS_MURAL,
    BH_FORGE,
    BH_TOWER,
    BH_SHARD_SIGNAL,
    BH_EP1_SIGNAL,
    HL_VTS,
    WHS,
    OPC_ENTER,
    OPC_CM,
    GD_FLUTE,
    GD_BI,
    GD_CY,
    GD_SIW,
    GD_DEPTHS,
    GD_CORE,
    GD_TOWER_RULE,
    GD_TOWER_COMPLETE,
    GD_COORDINATES,
    GD_SHARD_SIGNAL,
    FROZEN_SHUTTLE,
    IL_CORE,
    SOLANUM_SHUTTLE,
    QM_LAND,
    QM_6L,
    QM_SIGNAL,
    DB_HARMONICA,
    DB_JELLY,
    DB_GRAVE,
    DB_VESSEL,
    DB_EP3_SIGNAL,
    FREQ_DISTRESS,
    FREQ_QUANTUM,
    FREQ_HIDE_SEEK,

    // DLC Locations
    // TODO

    // Logsanity Locations (SLF = Ship Log Fact)
    SLF__S_SUNSTATION_X1,
    SLF__S_SUNSTATION_X2,
    SLF__S_SUNSTATION_X3,
    SLF__S_SUNSTATION_X4,
    SLF__CT_CHERT_X1,
    SLF__CT_CHERT_X2,
    SLF__CT_CHERT_X3,
    SLF__CT_CHERT_X4,
    SLF__CT_CHERT_X5,
    SLF__CT_QUANTUM_MOON_LOCATOR_X1,
    SLF__CT_QUANTUM_MOON_LOCATOR_X2,
    SLF__CT_QUANTUM_MOON_LOCATOR_X3,
    SLF__CT_GRAVITY_CANNON_X1,
    SLF__CT_GRAVITY_CANNON_X2,
    SLF__CT_ESCAPE_POD_X1,
    SLF__CT_ESCAPE_POD_X2,
    SLF__CT_HIGH_ENERGY_LAB_X1,
    SLF__CT_HIGH_ENERGY_LAB_X2,
    SLF__CT_HIGH_ENERGY_LAB_X3,
    SLF__CT_WARP_TOWER_MAP_X1,
    SLF__CT_WARP_TOWER_MAP_X4,
    SLF__CT_WARP_TOWER_MAP_X3,
    SLF__CT_WARP_TOWER_MAP_X2,
    SLF__CT_SUNLESS_CITY_X1,
    SLF__CT_SUNLESS_CITY_X2,
    SLF__CT_SUNLESS_CITY_X3,
    SLF__CT_ANGLERFISH_FOSSIL_X1,
    SLF__CT_ANGLERFISH_FOSSIL_X2,
    SLF__CT_ANGLERFISH_FOSSIL_X3,
    SLF__CT_QUANTUM_CAVES_X1,
    SLF__CT_QUANTUM_CAVES_X2,
    SLF__CT_LAKEBED_CAVERN_X1,
    SLF__CT_LAKEBED_CAVERN_X2,
    SLF__CT_LAKEBED_CAVERN_X3,
    SLF__TT_WARP_TOWERS_X1,
    SLF__TT_WARP_TOWERS_X2,
    SLF__TT_TIME_LOOP_DEVICE_X1,
    SLF__TT_TIME_LOOP_DEVICE_X2,
    SLF__TT_TIME_LOOP_DEVICE_X3,
    SLF__TT_TIME_LOOP_DEVICE_X4,
    SLF__TT_TIME_LOOP_DEVICE_X5,
    SLF__TH_VILLAGE_X1,
    SLF__TH_VILLAGE_X2,
    SLF__TH_VILLAGE_X3,
    SLF__TH_ZERO_G_CAVE_X1,
    SLF__TH_ZERO_G_CAVE_X2,
    SLF__TH_IMPACT_CRATER_X1,
    SLF__TH_IMPACT_CRATER_X2,
    SLF__TH_IMPACT_CRATER_X3,
    SLF__TH_NOMAI_MINE_X1,
    SLF__TH_NOMAI_MINE_X2,
    SLF__TH_NOMAI_MINE_X3,
    SLF__TH_QUANTUM_SHARD_X1,
    SLF__TH_QUANTUM_SHARD_X2,
    SLF__TM_ESKER_X1,
    SLF__TM_NORTH_POLE_X1,
    SLF__TM_EYE_LOCATOR_X1,
    SLF__TM_EYE_LOCATOR_X2,
    SLF__BH_RIEBECK_X1,
    SLF__BH_RIEBECK_X2,
    SLF__BH_GRAVITY_CANNON_X1,
    SLF__BH_GRAVITY_CANNON_X2,
    SLF__BH_QUANTUM_RESEARCH_TOWER_X1,
    SLF__BH_QUANTUM_RESEARCH_TOWER_X2,
    SLF__BH_QUANTUM_RESEARCH_TOWER_X3,
    SLF__BH_QUANTUM_SHARD_X1,
    SLF__BH_QUANTUM_SHARD_X2,
    SLF__BH_QUANTUM_SHARD_X3,
    SLF__BH_WARP_RECEIVER_X1,
    SLF__BH_WARP_RECEIVER_X2,
    SLF__BH_ESCAPE_POD_X1,
    SLF__BH_ESCAPE_POD_X2,
    SLF__BH_OLD_SETTLEMENT_X1,
    SLF__BH_OLD_SETTLEMENT_X2,
    SLF__BH_OLD_SETTLEMENT_X3,
    SLF__BH_OLD_SETTLEMENT_X4,
    SLF__BH_MURAL_3_X1,
    SLF__BH_MURAL_2_X1,
    SLF__BH_MURAL_1_X1,
    SLF__BH_HANGING_CITY_X1,
    SLF__BH_HANGING_CITY_X2,
    SLF__BH_HANGING_CITY_X3,
    SLF__BH_HANGING_CITY_X4,
    // there are 5 BHF facts, but the game's fact ids skip over 2 for some reason
    SLF__BH_BLACK_HOLE_FORGE_X1,
    SLF__BH_BLACK_HOLE_FORGE_X3,
    SLF__BH_BLACK_HOLE_FORGE_X4,
    SLF__BH_BLACK_HOLE_FORGE_X5,
    SLF__BH_BLACK_HOLE_FORGE_X6,
    SLF__BH_WARP_ALIGNMENT_MAP_X1,
    SLF__BH_WARP_ALIGNMENT_MAP_X2,
    SLF__BH_WARP_ALIGNMENT_MAP_X3,
    SLF__BH_WARP_ALIGNMENT_MAP_X4,
    SLF__BH_OBSERVATORY_X1,
    SLF__BH_OBSERVATORY_X2,
    SLF__BH_OBSERVATORY_X3,
    SLF__BH_OBSERVATORY_X4,
    SLF__BH_TORNADO_SIMULATION_X1,
    SLF__BH_TORNADO_SIMULATION_X2,
    SLF__VM_VOLCANO_X1,
    SLF__VM_VOLCANO_X2,
    SLF__VM_VOLCANO_X3,
    SLF__GD_OCEAN_X1,
    SLF__GD_OCEAN_X2,
    SLF__GD_GABBRO_ISLAND_X0,
    SLF__GD_GABBRO_ISLAND_X1,
    SLF__GD_GABBRO_ISLAND_X2,
    SLF__GD_GABBRO_ISLAND_X3,
    SLF__GD_CONSTRUCTION_YARD_X1,
    SLF__GD_CONSTRUCTION_YARD_X2,
    SLF__GD_CONSTRUCTION_YARD_X3,
    SLF__GD_BRAMBLE_ISLAND_X1,
    SLF__GD_STATUE_ISLAND_X1,
    SLF__GD_STATUE_ISLAND_X2,
    SLF__GD_STATUE_WORKSHOP_X1,
    SLF__GD_STATUE_WORKSHOP_X2,
    SLF__GD_STATUE_WORKSHOP_X3,
    SLF__GD_QUANTUM_TOWER_X1,
    SLF__GD_QUANTUM_TOWER_X2,
    SLF__GD_QUANTUM_TOWER_X3,
    SLF__GD_QUANTUM_TOWER_X4,
    SLF__ORBITAL_PROBE_CANNON_X1,
    SLF__ORBITAL_PROBE_CANNON_X2,
    SLF__ORBITAL_PROBE_CANNON_X3,
    SLF__OPC_SUNKEN_MODULE_X1,
    SLF__OPC_SUNKEN_MODULE_X2,
    SLF__OPC_SUNKEN_MODULE_X3,
    SLF__OPC_EYE_COORDINATES_X1,
    SLF__OPC_BROKEN_MODULE_X1,
    SLF__OPC_BROKEN_MODULE_X2,
    SLF__OPC_BROKEN_MODULE_X3,
    SLF__OPC_INTACT_MODULE_X1,
    SLF__OPC_INTACT_MODULE_X2,
    SLF__DB_FELDSPAR_X1,
    SLF__DB_FELDSPAR_X2,
    SLF__DB_FELDSPAR_X3,
    SLF__DB_FROZEN_JELLYFISH_X1,
    SLF__DB_FROZEN_JELLYFISH_X2,
    SLF__DB_FROZEN_JELLYFISH_X3,
    SLF__DB_ESCAPE_POD_X1,
    SLF__DB_ESCAPE_POD_X2,
    SLF__DB_ESCAPE_POD_X3,
    SLF__DB_NOMAI_GRAVE_X1,
    SLF__DB_NOMAI_GRAVE_X2,
    SLF__DB_NOMAI_GRAVE_X3,
    SLF__DB_NOMAI_GRAVE_X4,
    SLF__DB_VESSEL_X1,
    SLF__DB_VESSEL_X2,
    SLF__DB_VESSEL_X3,
    SLF__DB_VESSEL_X4,
    SLF__DB_VESSEL_X5,
    SLF__DB_VESSEL_X6,
    SLF__WHS_X1,
    SLF__WHS_X2,
    SLF__WHS_X3,
    SLF__WHS_X4,
    SLF__COMET_SHUTTLE_X1,
    SLF__COMET_SHUTTLE_X2,
    SLF__COMET_SHUTTLE_X3,
    SLF__COMET_SHUTTLE_X4,
    SLF__COMET_INTERIOR_X1,
    SLF__COMET_INTERIOR_X2,
    SLF__COMET_INTERIOR_X3,
    SLF__COMET_INTERIOR_X4,
    SLF__QUANTUM_MOON_X1,
    SLF__QUANTUM_MOON_X2,
    SLF__QM_SHUTTLE_X1,
    SLF__QM_SHUTTLE_X2,
    SLF__QM_SHRINE_X1,
    SLF__QM_SHRINE_X2,
    SLF__QM_SHRINE_X3,
    SLF__QM_SHRINE_X4,
    SLF__QM_SIXTH_LOCATION_X1,
    SLF__QM_SIXTH_LOCATION_X3,
    SLF__QM_SIXTH_LOCATION_X5,
    SLF__QM_SIXTH_LOCATION_X4,
    SLF__QM_SIXTH_LOCATION_X2,
    SLF__QM_SIXTH_LOCATION_X6,

    /* DLC & Logsanity Locations
    SLF__TH_RADIO_TOWER_X1,
    SLF__IP_RING_WORLD_X1,
    SLF__IP_ZONE_1_X1,
    SLF__IP_ZONE_1_X2,
    SLF__IP_ZONE_1_STORY_X1,
    SLF__IP_ZONE_1_STORY_X2,
    SLF__IP_ZONE_1_SECRET_X2,
    SLF__IP_ZONE_1_SECRET_X1,
    SLF__IP_ZONE_2_X1,
    SLF__IP_ZONE_2_X2,
    SLF__IP_ZONE_2_STORY_X1,
    SLF__IP_ZONE_2_STORY_X2,
    SLF__IP_ZONE_2_SECRET_X2,
    SLF__IP_ZONE_2_SECRET_X1,
    SLF__IP_ZONE_2_LIGHTHOUSE_X2,
    SLF__IP_ZONE_2_LIGHTHOUSE_X1,
    SLF__IP_ZONE_2_CODE_X1,
    SLF__IP_ZONE_2_CODE_X2,
    SLF__IP_ZONE_2_CODE_X3,
    SLF__IP_ZONE_3_X1,
    SLF__IP_ZONE_3_SECRET_X2,
    SLF__IP_ZONE_3_SECRET_X1,
    SLF__IP_ZONE_3_STORY_X1,
    SLF__IP_ZONE_3_STORY_X2,
    SLF__IP_ZONE_3_ENTRANCE_X1,
    SLF__IP_ZONE_3_ENTRANCE_X2,
    SLF__IP_ZONE_3_ENTRANCE_X3,
    SLF__IP_ZONE_3_LAB_X1,
    SLF__IP_ZONE_3_LAB_X3,
    SLF__IP_ZONE_3_LAB_X4,
    SLF__IP_ZONE_3_LAB_X2,
    SLF__IP_MAP_PROJECTION_1_X1,
    SLF__IP_MAP_PROJECTION_2_X1,
    SLF__IP_MAP_PROJECTION_3_X1,
    SLF__IP_ZONE_4_X2,
    SLF__IP_ZONE_4_X3,
    SLF__IP_ZONE_4_X4,
    SLF__IP_ZONE_4_STORY_X1,
    SLF__IP_ZONE_4_STORY_X2,
    SLF__IP_PRISON_X1,
    SLF__IP_PRISON_X2,
    SLF__IP_DREAM_LAKE_X1,
    SLF__IP_DREAM_LAKE_X2,
    SLF__IP_SARCOPHAGUS_X2,
    SLF__IP_SARCOPHAGUS_X3,
    SLF__IP_SARCOPHAGUS_X4,
    SLF__IP_SARCOPHAGUS_X5,
    SLF__IP_DREAM_ZONE_1_X1,
    SLF__IP_DREAM_ZONE_1_X2,
    SLF__IP_DREAM_ZONE_1_X3,
    SLF__IP_DREAM_LIBRARY_1_X1,
    SLF__IP_DREAM_LIBRARY_1_X2,
    SLF__IP_DREAM_1_STORY_X1,
    SLF__IP_DREAM_1_STORY_X2,
    SLF__IP_DREAM_1_RULE_X1,
    SLF__IP_DREAM_ZONE_2_X1,
    SLF__IP_DREAM_ZONE_2_X2,
    SLF__IP_DREAM_ZONE_2_X3,
    SLF__IP_DREAM_ZONE_2_X4,
    SLF__IP_DREAM_LIBRARY_2_X1,
    SLF__IP_DREAM_LIBRARY_2_X2,
    SLF__IP_DREAM_2_STORY_X1,
    SLF__IP_DREAM_2_STORY_X2,
    SLF__IP_DREAM_2_RULE_X1,
    SLF__IP_DREAM_2_RULE_X2,
    SLF__IP_DREAM_ZONE_3_X1,
    SLF__IP_DREAM_ZONE_3_X2,
    SLF__IP_DREAM_LIBRARY_3_X1,
    SLF__IP_DREAM_LIBRARY_3_X2,
    SLF__IP_DREAM_3_STORY_X1,
    SLF__IP_DREAM_3_STORY_X2,
    SLF__IP_DREAM_3_RULE_X1,
    */

    /* Rumorsanity Locations
    SLF__S_SUNSTATION_R1,
    SLF__S_SUNSTATION_R2,
    SLF__S_SUNSTATION_R3,
    SLF__CT_GRAVITY_CANNON_R1,
    SLF__CT_ESCAPE_POD_R1,
    SLF__CT_ESCAPE_POD_R2,
    SLF__CT_HIGH_ENERGY_LAB_R1,
    SLF__CT_HIGH_ENERGY_LAB_R2,
    SLF__CT_HIGH_ENERGY_LAB_R3,
    SLF__CT_WARP_TOWER_MAP_R1,
    SLF__CT_SUNLESS_CITY_R1,
    SLF__CT_SUNLESS_CITY_R3,
    SLF__CT_SUNLESS_CITY_R4,
    SLF__CT_SUNLESS_CITY_R5,
    SLF__CT_SUNLESS_CITY_R2,
    SLF__CT_ANGLERFISH_FOSSIL_R1,
    SLF__CT_ANGLERFISH_FOSSIL_R2,
    SLF__CT_ANGLERFISH_FOSSIL_R3,
    SLF__CT_ANGLERFISH_FOSSIL_R4,
    SLF__CT_QUANTUM_CAVES_R1,
    SLF__CT_LAKEBED_CAVERN_R1,
    SLF__CT_LAKEBED_CAVERN_R2,
    SLF__TT_TIME_LOOP_DEVICE_R1,
    SLF__TT_TIME_LOOP_DEVICE_R2,
    SLF__TT_TIME_LOOP_DEVICE_R3,
    SLF__TT_TIME_LOOP_DEVICE_R4,
    SLF__TH_ZERO_G_CAVE_R1,
    SLF__TH_IMPACT_CRATER_R1,
    SLF__TH_NOMAI_MINE_R1,
    SLF__TH_QUANTUM_SHARD_R1,
    SLF__TH_QUANTUM_SHARD_R2,
    SLF__TM_ESKER_R1,
    SLF__TM_NORTH_POLE_R1,
    SLF__TM_EYE_LOCATOR_R1,
    SLF__TM_EYE_LOCATOR_R2,
    SLF__BH_RIEBECK_R1,
    SLF__BH_RIEBECK_R2,
    SLF__BH_RIEBECK_R3,
    SLF__BH_RIEBECK_R4,
    SLF__BH_QUANTUM_RESEARCH_TOWER_R1,
    SLF__BH_QUANTUM_RESEARCH_TOWER_R2,
    SLF__BH_QUANTUM_SHARD_R1,
    SLF__BH_ESCAPE_POD_R1,
    SLF__BH_OLD_SETTLEMENT_R1,
    SLF__BH_HANGING_CITY_R1,
    SLF__BH_HANGING_CITY_R2,
    SLF__BH_BLACK_HOLE_FORGE_R1,
    SLF__BH_BLACK_HOLE_FORGE_R2,
    SLF__BH_BLACK_HOLE_FORGE_R3,
    SLF__BH_BLACK_HOLE_FORGE_R4,
    SLF__BH_OBSERVATORY_R1,
    SLF__BH_OBSERVATORY_R2,
    SLF__BH_OBSERVATORY_R3,
    SLF__BH_OBSERVATORY_R4,
    SLF__BH_TORNADO_SIMULATION_R1,
    SLF__GD_OCEAN_R1,
    SLF__GD_OCEAN_R2,
    SLF__GD_OCEAN_R3,
    SLF__GD_GABBRO_ISLAND_R1,
    SLF__GD_CONSTRUCTION_YARD_R1,
    SLF__GD_STATUE_ISLAND_R1,
    SLF__GD_STATUE_ISLAND_R2,
    SLF__GD_STATUE_WORKSHOP_R1,
    SLF__GD_STATUE_WORKSHOP_R2,
    SLF__GD_STATUE_WORKSHOP_R3,
    SLF__GD_QUANTUM_TOWER_R1,
    SLF__ORBITAL_PROBE_CANNON_R1,
    SLF__ORBITAL_PROBE_CANNON_R2,
    SLF__ORBITAL_PROBE_CANNON_R4,
    SLF__ORBITAL_PROBE_CANNON_R3,
    SLF__OPC_SUNKEN_MODULE_R1,
    SLF__OPC_SUNKEN_MODULE_R5,
    SLF__OPC_SUNKEN_MODULE_R4,
    SLF__OPC_SUNKEN_MODULE_R2,
    SLF__OPC_SUNKEN_MODULE_R3,
    SLF__OPC_BROKEN_MODULE_R1,
    SLF__OPC_BROKEN_MODULE_R2,
    SLF__OPC_BROKEN_MODULE_R3,
    SLF__OPC_INTACT_MODULE_R1,
    SLF__DB_FELDSPAR_R1,
    SLF__DB_FELDSPAR_R2,
    SLF__DB_FROZEN_JELLYFISH_R1,
    SLF__DB_ESCAPE_POD_R1,
    SLF__DB_NOMAI_GRAVE_R1,
    SLF__DB_NOMAI_GRAVE_R2,
    SLF__DB_VESSEL_R1,
    SLF__DB_VESSEL_R2,
    SLF__DB_VESSEL_R3,
    SLF__DB_VESSEL_R4,
    SLF__WHS_R1,
    SLF__WHS_R2,
    SLF__WHS_R3,
    SLF__WHS_R4,
    SLF__COMET_INTERIOR_R1,
    SLF__COMET_INTERIOR_R2,
    SLF__QUANTUM_MOON_R1,
    SLF__QUANTUM_MOON_R2,
    SLF__QUANTUM_MOON_R3,
    SLF__QUANTUM_MOON_R4,
    SLF__QM_SHRINE_R1,
    SLF__QM_SIXTH_LOCATION_R1,
    SLF__QM_SIXTH_LOCATION_R2,
    SLF__QM_SIXTH_LOCATION_R3,
     */

    /* DLC & Rumorsanity Locations
    SLF__IP_ZONE_1_SECRET_R1,
    SLF__IP_ZONE_2_SECRET_R1,
    SLF__IP_ZONE_2_LIGHTHOUSE_R1,
    SLF__IP_ZONE_2_CODE_R1,
    SLF__IP_ZONE_2_CODE_R2,
    SLF__IP_ZONE_3_SECRET_R1,
    SLF__IP_ZONE_3_ENTRANCE_R1,
    SLF__IP_ZONE_3_LAB_R1,
    SLF__IP_PRISON_R1,
    SLF__IP_PRISON_R2,
    SLF__IP_DREAM_LAKE_R1,
    SLF__IP_DREAM_LAKE_R2,
    SLF__IP_SARCOPHAGUS_R4,
    SLF__IP_SARCOPHAGUS_R1,
    SLF__IP_SARCOPHAGUS_R2,
    SLF__IP_SARCOPHAGUS_R3,
    SLF__IP_DREAM_ZONE_1_R1,
    SLF__IP_DREAM_LIBRARY_1_R1,
    SLF__IP_DREAM_ZONE_2_R1,
    SLF__IP_DREAM_LIBRARY_2_R1,
    SLF__IP_DREAM_ZONE_3_R1,
    SLF__IP_DREAM_LIBRARY_3_R1,
     */
};

public static class LocationNames
{
    public static bool IsDefaultLocation(Location location) =>
        location >= Location.SS && location <= Location.FREQ_HIDE_SEEK;
    public static bool IsDLCLocation(Location location) =>
        false;
    public static bool IsLogsanityLocation(Location location) =>
        location >= Location.SLF__S_SUNSTATION_X1 && location <= Location.SLF__QM_SIXTH_LOCATION_X6;
    public static bool IsDLCLogsanityLocation(Location location) =>
        false;

    public static Dictionary<Location, string> locationNames = new Dictionary<Location, string> {
        { Location.SS, "Sun Station (Projection Stone Text)" },

        { Location.ET_HEL, "ET: High Energy Lab (Upper Text Wall)" },
        { Location.ET_SC_SHRINE, "ET: Sunless City Shrine (Entrance Text Wall)" },
        { Location.ET_QML, "ET: Quantum Moon Locator (2nd Scroll)" },
        { Location.ET_FOSSIL, "ET: Fossil (Children's Text)" },
        { Location.ET_LAKEBED_CAVE, "ET: Lakebed Cave (Floor Text)" },
        { Location.ET_COLEUS_CAVE, "ET: Coleus' Cave (Text Wall)" },

        { Location.AT_ATP, "Enter the Ash Twin Project" },

        { Location.TH_GM, "TH: Ghost Matter Plaque" },
        { Location.TH_ZERO_G, "TH: Zero-G Repairs" },
        { Location.TH_HAL, "TH: Get the Translator from Hal" },
        { Location.TH_HORNFELS, "TH: Talk to Hornfels" },
        { Location.TH_SEED_CRATER, "TH: Talk to Tektite about Bramble Seed" },
        { Location.TH_MINES, "TH: Mines (Text Wall)" },

        { Location.AR_ESL, "AR: Signal Locator (Text Wall)" },

        { Location.BH_OBSERVATORY, "BH: Southern Observatory (Tornado Text Wall)" },
        { Location.BH_OS_MURAL, "BH: Old Settlement Murals" },
        { Location.BH_FORGE, "BH: Forge (2nd Scroll)" },
        { Location.BH_TOWER, "BH: Tower (Top Floor Text Wall)" },

        { Location.HL_VTS, "Volcanic Testing Site (Text Wall)" },

        { Location.WHS, "WHS (Text Wall)" },

        { Location.OPC_ENTER, "GD: Enter the Orbital Probe Cannon" },
        { Location.OPC_CM, "GD: Control Module Logs (Text Wheels)" },
        { Location.GD_BI, "GD: Bramble Island (Tape Recorder)" },
        { Location.GD_CY, "GD: Construction Yard (Text Wall)" },
        { Location.GD_SIW, "GD: Statue Island Workshop (Text Wheel)" },
        { Location.GD_DEPTHS, "GD: Enter the Ocean Depths" },
        { Location.GD_CORE, "GD: Enter the Core" },
        { Location.GD_TOWER_RULE, "GD: Tower Rule (Pedestal Text)" },
        { Location.GD_TOWER_COMPLETE, "GD: Complete the Tower (Text Wall)" },
        { Location.GD_COORDINATES, "GD: See the Coordinates" }, // spoiler-free name, as opposed to e.g. "Eye of the Universe Coordinates"

        { Location.FROZEN_SHUTTLE, "Frozen Shuttle Log (Text Wheel)" },
        { Location.IL_CORE, "Ruptured Core (Text Wheel)" }, // spoiler-free name, as opposed to e.g. "Interloper Core"

        { Location.QM_LAND, "QM: Land" },
        { Location.SOLANUM_SHUTTLE, "Solanum's Shuttle Log (Text Wheel)" },
        { Location.QM_6L, "QM: Explore the Sixth Location" }, // spoiler-free name, as opposed to e.g. "Meet Solanum"

        { Location.DB_JELLY, "DB: Feldspar's Note" }, // spoiler-free name, as opposed to e.g. "Frozen Jellyfish Note"
        { Location.DB_GRAVE, "DB: Nomai Grave (Text Wheel)" },
        { Location.DB_VESSEL, "DB: Find The Vessel" },

        { Location.FREQ_DISTRESS, "Distress Beacon Frequency" },
        { Location.FREQ_QUANTUM, "Quantum Fluctuations Frequency" },
        { Location.FREQ_HIDE_SEEK, "Hide & Seek Frequency" },

        { Location.ET_DRUM, "ET: Drum Signal" },
        { Location.AR_WHISTLE, "AR: Whistling Signal" },
        { Location.BH_BANJO, "BH: Banjo Signal" },
        { Location.GD_FLUTE, "GD: Flute Signal" },
        { Location.DB_HARMONICA, "DB: Harmonica Signal" },
        { Location.TH_MS_SIGNAL, "TH: Museum Shard Signal" },
        { Location.TH_GS_SIGNAL, "TH: Grove Shard Signal" },
        { Location.ET_SHARD_SIGNAL, "ET: Cave Shard Signal" },
        { Location.BH_SHARD_SIGNAL, "BH: Tower Shard Signal" },
        { Location.GD_SHARD_SIGNAL, "GD: Island Shard Signal" },
        { Location.QM_SIGNAL, "Quantum Moon Signal" },
        { Location.BH_EP1_SIGNAL, "BH: Escape Pod 1 Signal" },
        { Location.ET_EP2_SIGNAL, "ET: Escape Pod 2 Signal" },
        { Location.DB_EP3_SIGNAL, "DB: Escape Pod 3 Signal" },
        { Location.TH_GALENA_SIGNAL, "TH: Galena's Radio Signal" },
        { Location.TH_TEPHRA_SIGNAL, "TH: Tephra's Radio Signal" },

        // Logsanity locations
        { Location.SLF__S_SUNSTATION_X1, "Ship Log: Sun Station 1 - Purpose" },
        { Location.SLF__S_SUNSTATION_X2, "Ship Log: Sun Station 2 - Test Result" },
        { Location.SLF__S_SUNSTATION_X3, "Ship Log: Sun Station 3 - Comet" },
        { Location.SLF__S_SUNSTATION_X4, "Ship Log: Sun Station 4 - Natural End" },
        { Location.SLF__CT_CHERT_X1, "Ship Log: Chert's Camp 1 - Visit" },
        { Location.SLF__CT_CHERT_X2, "Ship Log: Chert's Camp 2 - Supernovae" },
        { Location.SLF__CT_CHERT_X3, "Ship Log: Chert's Camp 3 - Universe Dying" },
        { Location.SLF__CT_CHERT_X4, "Ship Log: Chert's Camp 4 - Old Age" },
        { Location.SLF__CT_CHERT_X5, "Ship Log: Chert's Camp 5 - Imminent Death" },
        { Location.SLF__CT_QUANTUM_MOON_LOCATOR_X1, "Ship Log: QM Locator 1 - Purpose" },
        { Location.SLF__CT_QUANTUM_MOON_LOCATOR_X2, "Ship Log: QM Locator 2 - Quantum Mechanics" },
        { Location.SLF__CT_QUANTUM_MOON_LOCATOR_X3, "Ship Log: QM Locator 3 - Five Locations" },
        { Location.SLF__CT_GRAVITY_CANNON_X1, "Ship Log: ET Gravity Cannon 1 - Visit" },
        { Location.SLF__CT_GRAVITY_CANNON_X2, "Ship Log: ET Gravity Cannon 2 - Recall Shuttle" },
        { Location.SLF__CT_ESCAPE_POD_X1, "Ship Log: Escape Pod 2 1 - Identify" },
        { Location.SLF__CT_ESCAPE_POD_X2, "Ship Log: Escape Pod 2 2 - Vessel" },
        { Location.SLF__CT_HIGH_ENERGY_LAB_X1, "Ship Log: High Energy Lab 1 - Temporal Anomaly" },
        { Location.SLF__CT_HIGH_ENERGY_LAB_X2, "Ship Log: High Energy Lab 2 - Increasing Interval" },
        { Location.SLF__CT_HIGH_ENERGY_LAB_X3, "Ship Log: High Energy Lab 3 - Ash Twin Project" },
        { Location.SLF__CT_WARP_TOWER_MAP_X1, "Ship Log: AT Tower Designs 1 - Identify" },
        { Location.SLF__CT_WARP_TOWER_MAP_X4, "Ship Log: AT Tower Designs 2 - Different Planets" },
        { Location.SLF__CT_WARP_TOWER_MAP_X3, "Ship Log: AT Tower Designs 3 - Reflect Destinations" },
        { Location.SLF__CT_WARP_TOWER_MAP_X2, "Ship Log: AT Tower Designs 4 - Ash Twin Project" },
        { Location.SLF__CT_SUNLESS_CITY_X1, "Ship Log: Sunless City 1 - Identify" },
        { Location.SLF__CT_SUNLESS_CITY_X2, "Ship Log: Sunless City 2 - Sun Station Debate" },
        { Location.SLF__CT_SUNLESS_CITY_X3, "Ship Log: Sunless City 3 - Eye Signal" },
        { Location.SLF__CT_ANGLERFISH_FOSSIL_X1, "Ship Log: Anglerfish Fossil 1 - Children's Game" },
        { Location.SLF__CT_ANGLERFISH_FOSSIL_X2, "Ship Log: Anglerfish Fossil 2 - Blindfold Rule" },
        { Location.SLF__CT_ANGLERFISH_FOSSIL_X3, "Ship Log: Anglerfish Fossil 3 - Adult Response" },
        { Location.SLF__CT_QUANTUM_CAVES_X1, "Ship Log: Quantum Caves 1 - Wandering Rock" },
        { Location.SLF__CT_QUANTUM_CAVES_X2, "Ship Log: Quantum Caves 2 - Quantum Signal" },
        { Location.SLF__CT_LAKEBED_CAVERN_X1, "Ship Log: Lakebed Cave 1 - Coleus Disappeared" },
        { Location.SLF__CT_LAKEBED_CAVERN_X2, "Ship Log: Lakebed Cave 2 - Entanglement Rule" },
        { Location.SLF__CT_LAKEBED_CAVERN_X3, "Ship Log: Lakebed Cave 3 - Conscious Being Theory" },
        { Location.SLF__TT_WARP_TOWERS_X1, "Ship Log: AT Towers 1 - Identify" },
        { Location.SLF__TT_WARP_TOWERS_X2, "Ship Log: AT Towers 2 - White Hole Station" },
        { Location.SLF__TT_TIME_LOOP_DEVICE_X1, "Ship Log: ATP 1 - Entered" },
        { Location.SLF__TT_TIME_LOOP_DEVICE_X2, "Ship Log: ATP 2 - Mask Monoliths" },
        { Location.SLF__TT_TIME_LOOP_DEVICE_X3, "Ship Log: ATP 3 - Supernova Energy" },
        { Location.SLF__TT_TIME_LOOP_DEVICE_X4, "Ship Log: ATP 4 - Sun Station Failure" },
        { Location.SLF__TT_TIME_LOOP_DEVICE_X5, "Ship Log: ATP 5 - Advanced Warp Core" },
        { Location.SLF__TH_VILLAGE_X1, "Ship Log: Village 1 - Identify" },
        { Location.SLF__TH_VILLAGE_X2, "Ship Log: Village 2 - Statue Eyes Opened" },
        { Location.SLF__TH_VILLAGE_X3, "Ship Log: Village 3 - Never Opened Before" },
        { Location.SLF__TH_ZERO_G_CAVE_X1, "Ship Log: Zero-G Cave 1 - Identify" },
        { Location.SLF__TH_ZERO_G_CAVE_X2, "Ship Log: Zero-G Cave 2 - Repair" },
        { Location.SLF__TH_IMPACT_CRATER_X1, "Ship Log: Dark Bramble Seed 1 - Tektite" },
        { Location.SLF__TH_IMPACT_CRATER_X2, "Ship Log: Dark Bramble Seed 2 - Harmonica Signal" },
        { Location.SLF__TH_IMPACT_CRATER_X3, "Ship Log: Dark Bramble Seed 3 - Scout Photos" },
        { Location.SLF__TH_NOMAI_MINE_X1, "Ship Log: Nomai Mines 1 - Ash Twin Shell" },
        { Location.SLF__TH_NOMAI_MINE_X2, "Ship Log: Nomai Mines 2 - No Physical Entrance" },
        { Location.SLF__TH_NOMAI_MINE_X3, "Ship Log: Nomai Mines 3 - Four-Eyed Lifeforms" },
        { Location.SLF__TH_QUANTUM_SHARD_X1, "Ship Log: Quantum Grove 1 - Quantum Signal" },
        { Location.SLF__TH_QUANTUM_SHARD_X2, "Ship Log: Quantum Grove 2 - Poem" },
        { Location.SLF__TM_ESKER_X1, "Ship Log: Esker's Camp" },
        { Location.SLF__TM_NORTH_POLE_X1, "Ship Log: Lunar Lookout" },
        { Location.SLF__TM_EYE_LOCATOR_X1, "Ship Log: Eye Signal Locator 1 - Identify" },
        { Location.SLF__TM_EYE_LOCATOR_X2, "Ship Log: Eye Signal Locator 2 - Failure" },
        { Location.SLF__BH_RIEBECK_X1, "Ship Log: Riebeck's Camp 1 - Visit" },
        { Location.SLF__BH_RIEBECK_X2, "Ship Log: Riebeck's Camp 2 - Archaeology" },
        { Location.SLF__BH_GRAVITY_CANNON_X1, "Ship Log: BH Gravity Cannon 1 - Visit" },
        { Location.SLF__BH_GRAVITY_CANNON_X2, "Ship Log: BH Gravity Cannon 2 - Recall Shuttle" },
        { Location.SLF__BH_QUANTUM_RESEARCH_TOWER_X1, "Ship Log: BH Tower 1 - Sixth Location" },
        { Location.SLF__BH_QUANTUM_RESEARCH_TOWER_X2, "Ship Log: BH Tower 2 - Pilgrimage" },
        { Location.SLF__BH_QUANTUM_RESEARCH_TOWER_X3, "Ship Log: BH Tower 3 - United Goal" },
        { Location.SLF__BH_QUANTUM_SHARD_X1, "Ship Log: Tower Shard 1 - Grove Objects" },
        { Location.SLF__BH_QUANTUM_SHARD_X2, "Ship Log: Tower Shard 2 - Piece of Moon" },
        { Location.SLF__BH_QUANTUM_SHARD_X3, "Ship Log: Tower Shard 3 - QM Signal" },
        { Location.SLF__BH_WARP_RECEIVER_X1, "Ship Log: Northern Glacier 1 - Visit" },
        { Location.SLF__BH_WARP_RECEIVER_X2, "Ship Log: Northern Glacier 2 - WHS" },
        { Location.SLF__BH_ESCAPE_POD_X1, "Ship Log: Escape Pod 1 1 - Identify" },
        { Location.SLF__BH_ESCAPE_POD_X2, "Ship Log: Escape Pod 1 2 - Vessel" },
        { Location.SLF__BH_OLD_SETTLEMENT_X1, "Ship Log: Old Settlement 1 - Identify" },
        { Location.SLF__BH_OLD_SETTLEMENT_X2, "Ship Log: Old Settlement 2 - Eye-Shaped Signal" },
        { Location.SLF__BH_OLD_SETTLEMENT_X3, "Ship Log: Old Settlement 3 - Eye of the Universe" },
        { Location.SLF__BH_OLD_SETTLEMENT_X4, "Ship Log: Old Settlement 4 - Abandoned" },
        { Location.SLF__BH_MURAL_3_X1, "Ship Log: Old Settlement Mural 3" },
        { Location.SLF__BH_MURAL_2_X1, "Ship Log: Old Settlement Mural 2" },
        { Location.SLF__BH_MURAL_1_X1, "Ship Log: Old Settlement Mural 1" },
        { Location.SLF__BH_HANGING_CITY_X1, "Ship Log: Hanging City 1 - Visit" },
        { Location.SLF__BH_HANGING_CITY_X2, "Ship Log: Hanging City 2 - BHF Switch" },
        { Location.SLF__BH_HANGING_CITY_X3, "Ship Log: Hanging City 3 - Warp Core" },
        { Location.SLF__BH_HANGING_CITY_X4, "Ship Log: Hanging City 4 - Eye Signal" },
        { Location.SLF__BH_BLACK_HOLE_FORGE_X1, "Ship Log: Black Hole Forge 1 - Astral Body Alignment" },
        { Location.SLF__BH_BLACK_HOLE_FORGE_X3, "Ship Log: Black Hole Forge 2 - Receiver Location" },
        { Location.SLF__BH_BLACK_HOLE_FORGE_X4, "Ship Log: Black Hole Forge 3 - Hourglass Twins" },
        { Location.SLF__BH_BLACK_HOLE_FORGE_X5, "Ship Log: Black Hole Forge 4 - Ash Twin Towers" },
        { Location.SLF__BH_BLACK_HOLE_FORGE_X6, "Ship Log: Black Hole Forge 5 - Poke's Warp Core" },
        { Location.SLF__BH_WARP_ALIGNMENT_MAP_X1, "Ship Log: Alignment Angle Diagram 1 - Identify" },
        { Location.SLF__BH_WARP_ALIGNMENT_MAP_X2, "Ship Log: Alignment Angle Diagram 2 - Five Degrees" },
        { Location.SLF__BH_WARP_ALIGNMENT_MAP_X3, "Ship Log: Alignment Angle Diagram 3 - Several Seconds" },
        { Location.SLF__BH_WARP_ALIGNMENT_MAP_X4, "Ship Log: Alignment Angle Diagram 4 - Active Window" },
        { Location.SLF__BH_OBSERVATORY_X1, "Ship Log: Southern Observatory 1 - Eye Signal" },
        { Location.SLF__BH_OBSERVATORY_X2, "Ship Log: Southern Observatory 2 - Distant Orbit" },
        { Location.SLF__BH_OBSERVATORY_X3, "Ship Log: Southern Observatory 3 - Deep Space Probe" },
        { Location.SLF__BH_OBSERVATORY_X4, "Ship Log: Southern Observatory 4 - Probability" },
        { Location.SLF__BH_TORNADO_SIMULATION_X1, "Ship Log: Tornado Simulation 1 - Mostly Clockwise" },
        { Location.SLF__BH_TORNADO_SIMULATION_X2, "Ship Log: Tornado Simulation 2 - Below the Current" },
        { Location.SLF__VM_VOLCANO_X1, "Ship Log: Volcanic Testing Site 1 - Purpose" },
        { Location.SLF__VM_VOLCANO_X2, "Ship Log: Volcanic Testing Site 2 - Briefly Supernova-Proof" },
        { Location.SLF__VM_VOLCANO_X3, "Ship Log: Volcanic Testing Site 3 - Smallest Crack" },
        { Location.SLF__GD_OCEAN_X1, "Ship Log: Ocean Depths 1 - Electrical Field" },
        { Location.SLF__GD_OCEAN_X2, "Ship Log: Ocean Depths 2 - Coral Forest" },
        { Location.SLF__GD_GABBRO_ISLAND_X0, "Ship Log: Gabbro's Island 1 - Hammock" },
        { Location.SLF__GD_GABBRO_ISLAND_X1, "Ship Log: Gabbro's Island 2 - Gabbro's Statue" },
        { Location.SLF__GD_GABBRO_ISLAND_X2, "Ship Log: Gabbro's Island 3 - Remembers Dying" },
        { Location.SLF__GD_GABBRO_ISLAND_X3, "Ship Log: Gabbro's Island 4 - Only Two Aware" },
        { Location.SLF__GD_CONSTRUCTION_YARD_X1, "Ship Log: Construction Yard 1 - Built OPC" },
        { Location.SLF__GD_CONSTRUCTION_YARD_X2, "Ship Log: Construction Yard 2 - Hiatus" },
        { Location.SLF__GD_CONSTRUCTION_YARD_X3, "Ship Log: Construction Yard 3 - Recent Launch" },
        { Location.SLF__GD_BRAMBLE_ISLAND_X1, "Ship Log: Bramble Island" },
        { Location.SLF__GD_STATUE_ISLAND_X1, "Ship Log: Statue Island 1 - Purpose" },
        { Location.SLF__GD_STATUE_ISLAND_X2, "Ship Log: Statue Island 2 - Beach Statue" },
        { Location.SLF__GD_STATUE_WORKSHOP_X1, "Ship Log: Island Workshop 1 - Memories" },
        { Location.SLF__GD_STATUE_WORKSHOP_X2, "Ship Log: Island Workshop 2 - Masks" },
        { Location.SLF__GD_STATUE_WORKSHOP_X3, "Ship Log: Island Workshop 3 - Activation" },
        { Location.SLF__GD_QUANTUM_TOWER_X1, "Ship Log: GD Tower 1 - Quantum Journey" },
        { Location.SLF__GD_QUANTUM_TOWER_X2, "Ship Log: GD Tower 2 - Observing an Image" },
        { Location.SLF__GD_QUANTUM_TOWER_X3, "Ship Log: GD Tower 3 - Rule of Imaging" },
        { Location.SLF__GD_QUANTUM_TOWER_X4, "Ship Log: GD Tower 4 - Other Shards" },
        { Location.SLF__ORBITAL_PROBE_CANNON_X1, "Ship Log: OPC 1 - Entered" },
        { Location.SLF__ORBITAL_PROBE_CANNON_X2, "Ship Log: OPC 2 - Purpose" },
        { Location.SLF__ORBITAL_PROBE_CANNON_X3, "Ship Log: OPC 3 - Maximum Power" },
        { Location.SLF__OPC_SUNKEN_MODULE_X1, "Ship Log: Probe Tracking Module 1 - Millions" },
        { Location.SLF__OPC_SUNKEN_MODULE_X2, "Ship Log: Probe Tracking Module 2 - Anomaly Located" },
        { Location.SLF__OPC_SUNKEN_MODULE_X3, "Ship Log: Probe Tracking Module 3 - Statue" },
        { Location.SLF__OPC_EYE_COORDINATES_X1, "Ship Log: Probe Tracking Module 4 - Coordinates" },
        { Location.SLF__OPC_BROKEN_MODULE_X1, "Ship Log: Launch Module 1 - Damaged" },
        { Location.SLF__OPC_BROKEN_MODULE_X2, "Ship Log: Launch Module 2 - Only Once" },
        { Location.SLF__OPC_BROKEN_MODULE_X3, "Ship Log: Launch Module 3 - Receive Data" },
        { Location.SLF__OPC_INTACT_MODULE_X1, "Ship Log: Control Module 1 - Recent Launch Request" },
        { Location.SLF__OPC_INTACT_MODULE_X2, "Ship Log: Control Module 2 - Compromised" },
        { Location.SLF__DB_FELDSPAR_X1, "Ship Log: Feldspar's Camp 1 - Alive" },
        { Location.SLF__DB_FELDSPAR_X2, "Ship Log: Feldspar's Camp 2 - Space Doesn't Work" },
        { Location.SLF__DB_FELDSPAR_X3, "Ship Log: Feldspar's Camp 3 - Peace And Quiet" },
        { Location.SLF__DB_FROZEN_JELLYFISH_X1, "Ship Log: Frozen Jellyfish 1 - Outside" },
        { Location.SLF__DB_FROZEN_JELLYFISH_X2, "Ship Log: Frozen Jellyfish 2 - Inside" },
        { Location.SLF__DB_FROZEN_JELLYFISH_X3, "Ship Log: Frozen Jellyfish 3 - Do Not Eat" },
        { Location.SLF__DB_ESCAPE_POD_X1, "Ship Log: Escape Pod 3 1 - Identify" },
        { Location.SLF__DB_ESCAPE_POD_X2, "Ship Log: Escape Pod 3 2 - Vessel" },
        { Location.SLF__DB_ESCAPE_POD_X3, "Ship Log: Escape Pod 3 3 - Two Beacons" },
        { Location.SLF__DB_NOMAI_GRAVE_X1, "Ship Log: Nomai Grave 1 - Followed Beacon" },
        { Location.SLF__DB_NOMAI_GRAVE_X2, "Ship Log: Nomai Grave 2 - Within the Seed" },
        { Location.SLF__DB_NOMAI_GRAVE_X3, "Ship Log: Nomai Grave 3 - Beacon Dying" },
        { Location.SLF__DB_NOMAI_GRAVE_X4, "Ship Log: Nomai Grave 4 - Scout Photos" },
        { Location.SLF__DB_VESSEL_X1, "Ship Log: The Vessel 1 - Entered" },
        { Location.SLF__DB_VESSEL_X2, "Ship Log: The Vessel 2 - Dead Core" },
        { Location.SLF__DB_VESSEL_X3, "Ship Log: The Vessel 3 - Input Pillar" },
        { Location.SLF__DB_VESSEL_X4, "Ship Log: The Vessel 4 - Call For Help" },
        { Location.SLF__DB_VESSEL_X5, "Ship Log: The Vessel 5 - Clans Regrouping" },
        { Location.SLF__DB_VESSEL_X6, "Ship Log: The Vessel 6 - Original Recording" },
        { Location.SLF__WHS_X1, "Ship Log: WHS 1 - Warp Towers" },
        { Location.SLF__WHS_X2, "Ship Log: WHS 2 - Alignment" },
        { Location.SLF__WHS_X3, "Ship Log: WHS 3 - Arrive Before" },
        { Location.SLF__WHS_X4, "Ship Log: WHS 4 - Miniscule Interval" },
        { Location.SLF__COMET_SHUTTLE_X1, "Ship Log: Frozen Shuttle 1 - Found" },
        { Location.SLF__COMET_SHUTTLE_X2, "Ship Log: Frozen Shuttle 2 - Energy Readings" },
        { Location.SLF__COMET_SHUTTLE_X3, "Ship Log: Frozen Shuttle 3 - Stayed Behind" },
        { Location.SLF__COMET_SHUTTLE_X4, "Ship Log: Frozen Shuttle 4 - Lost Contact" },
        { Location.SLF__COMET_INTERIOR_X1, "Ship Log: Ruptured Core 1 - Missing Crew" },
        { Location.SLF__COMET_INTERIOR_X2, "Ship Log: Ruptured Core 2 - Exotic Matter" },
        { Location.SLF__COMET_INTERIOR_X3, "Ship Log: Ruptured Core 3 - Instant Blanket" },
        { Location.SLF__COMET_INTERIOR_X4, "Ship Log: Ruptured Core 4 - Warn the Others" },
        { Location.SLF__QUANTUM_MOON_X1, "Ship Log: Quantum Moon 1 - Land" },
        { Location.SLF__QUANTUM_MOON_X2, "Ship Log: Quantum Moon 2 - Corpse" },
        { Location.SLF__QM_SHUTTLE_X1, "Ship Log: Solanum's Shuttle 1 - Landing" },
        { Location.SLF__QM_SHUTTLE_X2, "Ship Log: Solanum's Shuttle 2 - South Pole" },
        { Location.SLF__QM_SHRINE_X1, "Ship Log: Quantum Shrine 1 - Identify" },
        { Location.SLF__QM_SHRINE_X2, "Ship Log: Quantum Shrine 2 - Imaging Rule" },
        { Location.SLF__QM_SHRINE_X3, "Ship Log: Quantum Shrine 3 - Entanglement Rule" },
        { Location.SLF__QM_SHRINE_X4, "Ship Log: Quantum Shrine 4 - Sixth Location Rule" },
        { Location.SLF__QM_SIXTH_LOCATION_X1, "Ship Log: Sixth Location 1 - Visit" },
        { Location.SLF__QM_SIXTH_LOCATION_X3, "Ship Log: Sixth Location 2 - Eye's Moon" },
        { Location.SLF__QM_SIXTH_LOCATION_X5, "Ship Log: Sixth Location 3 - Reflects Eye" },
        { Location.SLF__QM_SIXTH_LOCATION_X4, "Ship Log: Sixth Location 4 - Macro-Quantum Source" },
        { Location.SLF__QM_SIXTH_LOCATION_X2, "Ship Log: Sixth Location 5 - Conscious Observer" },
        { Location.SLF__QM_SIXTH_LOCATION_X6, "Ship Log: Sixth Location 6 - Not Entirely Alive" },
    };

    public static Dictionary<string, Location> locationNamesReversed = locationNames.ToDictionary(ln => ln.Value, ln => ln.Key);

    public static string LocationToName(Location location) => locationNames[location];
    public static Location NameToLocation(string locationName) => locationNamesReversed[locationName];

    public static Dictionary<SignalFrequency, Location> frequencyToLocation = new Dictionary<SignalFrequency, Location>{
        { SignalFrequency.EscapePod, Location.FREQ_DISTRESS },
        { SignalFrequency.Quantum, Location.FREQ_QUANTUM },
        { SignalFrequency.HideAndSeek, Location.FREQ_HIDE_SEEK },
        // DLC will add: SignalFrequency.Radio
        // left out Default, WarpCore and Statue because I don't believe they get used
    };
    public static Dictionary<Location, SignalFrequency> locationToFrequency = frequencyToLocation.ToDictionary(ftl => ftl.Value, ftl => ftl.Key);

    public static Dictionary<SignalName, Location> signalToLocation = new Dictionary<SignalName, Location>{
        { SignalName.Traveler_Chert, Location.ET_DRUM },
        { SignalName.Traveler_Esker, Location.AR_WHISTLE },
        { SignalName.Traveler_Riebeck, Location.BH_BANJO },
        { SignalName.Traveler_Gabbro, Location.GD_FLUTE },
        { SignalName.Traveler_Feldspar, Location.DB_HARMONICA },
        { SignalName.Quantum_TH_MuseumShard, Location.TH_MS_SIGNAL },
        { SignalName.Quantum_TH_GroveShard, Location.TH_GS_SIGNAL },
        { SignalName.Quantum_CT_Shard, Location.ET_SHARD_SIGNAL },
        { SignalName.Quantum_BH_Shard, Location.BH_SHARD_SIGNAL },
        { SignalName.Quantum_GD_Shard, Location.GD_SHARD_SIGNAL },
        { SignalName.Quantum_QM, Location.QM_SIGNAL },
        { SignalName.EscapePod_BH, Location.BH_EP1_SIGNAL },
        { SignalName.EscapePod_CT, Location.ET_EP2_SIGNAL },
        { SignalName.EscapePod_DB, Location.DB_EP3_SIGNAL },
        { SignalName.HideAndSeek_Galena, Location.TH_GALENA_SIGNAL },
        { SignalName.HideAndSeek_Tephra, Location.TH_TEPHRA_SIGNAL },
        // DLC will add: SignalName.RadioTower, SignalName.MapSatellite
        // left out Default, HideAndSeek_Arkose and all the White Hole signals because I don't believe they're used
        // left out Nomai and Prisoner because I believe those are only available during the finale
    };
    public static Dictionary<Location, SignalName> locationToSignal = signalToLocation.ToDictionary(stl => stl.Value, stl => stl.Key);

    // leave these as null until we load the ids, so any attempt to work with ids before that will fail loudly
    public static Dictionary<long, Location> archipelagoIdToLocation = null;
    public static Dictionary<Location, long> locationToArchipelagoId = null;

    public static void LoadArchipelagoIds(string locationsFilepath)
    {
        var locationsData = JArray.Parse(File.ReadAllText(locationsFilepath));
        archipelagoIdToLocation = new();
        locationToArchipelagoId = new();
        foreach (var locationData in locationsData)
        {
            // Skip event locations, since they intentionally don't have ids
            if (locationData["address"].Type == JTokenType.Null) continue;

            var archipelagoId = (long)locationData["address"];
            var name = (string)locationData["name"];

            if (!locationNamesReversed.ContainsKey(name))
                throw new System.Exception($"LoadArchipelagoIds failed: unknown location name {name}");

            var location = locationNamesReversed[name];
            archipelagoIdToLocation.Add(archipelagoId, location);
            locationToArchipelagoId.Add(location, archipelagoId);
        }
    }
};
