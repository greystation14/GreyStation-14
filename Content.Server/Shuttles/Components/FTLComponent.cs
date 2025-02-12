using Content.Shared.Shuttles.Systems;
using Content.Shared.Tag;
using Content.Shared.Timing;
using Robust.Shared.Audio;
using Robust.Shared.Map;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Shuttles.Components;

/// <summary>
/// Added to a component when it is queued or is travelling via FTL.
/// </summary>
[RegisterComponent]
public sealed partial class FTLComponent : Component
{
    [ViewVariables]
    public FTLState State = FTLState.Available;

    [ViewVariables(VVAccess.ReadWrite)]
    public StartEndTime StateTime;

    [ViewVariables(VVAccess.ReadWrite)]
    public float StartupTime = 0f;

    [ViewVariables(VVAccess.ReadWrite)]
    public float TravelTime = 0f;

    /// <summary>
    /// Coordinates to arrive it: May be relative to another grid (for docking) or map coordinates.
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite), DataField]
    public EntityCoordinates TargetCoordinates;

    [DataField]
    public Angle TargetAngle;

    /// <summary>
    /// If we're docking after FTL what is the prioritised dock tag (if applicable).
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite), DataField]
    public ProtoId<TagPrototype>? PriorityTag;

    [ViewVariables(VVAccess.ReadWrite), DataField("soundTravel")]
    public SoundSpecifier? TravelSound = new SoundPathSpecifier("/Audio/GreyStation/Effects/Shuttle/hyperspace_progress.ogg") // GreyStation - Replace FTL sound w/Nyanotrasen FTL Sound
    {
        Params = AudioParams.Default.WithVolume(-3f).WithLoop(true)
    };

    [DataField]
    public EntityUid? TravelStream;
}
