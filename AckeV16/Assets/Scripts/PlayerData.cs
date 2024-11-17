using Unity.Netcode;
using Unity.Collections;
using System;

public struct PlayerData : IEquatable<PlayerData>, INetworkSerializable
{
    public ulong clientId;
    public int spawnIndex;
    public int selectedSkin;
    public FixedString64Bytes playerName; // Use FixedString64Bytes for playerName
    public FixedString64Bytes playerId;

    public bool Equals(PlayerData other)
    {
        return clientId == other.clientId &&
               spawnIndex == other.spawnIndex &&
               selectedSkin == other.selectedSkin &&
               playerName.Equals(other.playerName) &&
               playerId == other.playerId;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref clientId);
        serializer.SerializeValue(ref spawnIndex);
        serializer.SerializeValue(ref selectedSkin);
        serializer.SerializeValue(ref playerName);
        serializer.SerializeValue(ref playerId); // Serialize playerId
    }
}
