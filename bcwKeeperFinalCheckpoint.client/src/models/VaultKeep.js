export class VaultKeep {
  constructor(data) {
    this.id = data.id
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.creatorId = data.creatorId
    this.vaultId = data.vaultId
    this.keepId = data.keepId
  }
}