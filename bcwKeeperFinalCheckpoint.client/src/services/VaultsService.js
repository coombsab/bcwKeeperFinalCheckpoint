import { AppState } from "../AppState"
import { Vault } from "../models/Vault"
import { api } from "./AxiosService"

class VaultsService {
  async getMyVaults() {
    AppState.myVaults = []
    const res = await api.get("account/vaults")
    AppState.myVaults = res.data.map(data => new Vault(data))
  }

  async setActiveVault(vaultId) {
    AppState.activeVault = null
    const res = await api.get(`api/vaults/${vaultId}`)
    AppState.activeVault = new Vault(res.data)
  }

  async createVault(vaultData) {
    const res = await api.post("api/vaults", vaultData)
    AppState.vaults.push(new Vault(res.data))
    AppState.myVaults.push(new Vault(res.data))
  }

  async deleteVault(vaultId) {
    await api.delete(`api/vaults/${vaultId}`)
    AppState.vaults = AppState.vaults.filter(vault => vault.id != vaultId)
    AppState.myVaults = AppState.myVaults.filter(vault => vault.id != vaultId)

  }

  async editVault(vaultData, vaultId) {
    const res = await api.put(`api/vaults/${vaultId}`, vaultData)
    const vault = new Vault(res.data)
    AppState.activeVault = vault

    let vaultIndex = AppState.vaults.findIndex(v => v.id == vaultId)
    if (vaultIndex >= 0) {
      AppState.vaults.splice(vaultIndex, 1, vault)
    }

    vaultIndex = AppState.myVaults.findIndex(v => v.id == vaultId)
    if (vaultIndex >= 0) {
      AppState.myVaults.splice(vaultIndex, 1, vault)
    }

  }
}

export const vaultsService = new VaultsService()