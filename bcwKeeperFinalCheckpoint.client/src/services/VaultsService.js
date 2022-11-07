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
}

export const vaultsService = new VaultsService()