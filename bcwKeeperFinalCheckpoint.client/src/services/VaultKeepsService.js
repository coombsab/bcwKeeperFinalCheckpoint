import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { api } from "./AxiosService"

class VaultKeepsService {
  async removeKeepFromVault(vaultKeepId) {
    await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    AppState.keepsInVault = AppState.keepsInVault.filter(keep => keep.vaultKeepId !== vaultKeepId)
  }

  async saveKeepToVault(vaultId, keepId) {
    await api.post("api/vaultkeeps", { vaultId, keepId })
    if (AppState.activeKeep) {
      AppState.activeKeep.kept++
    }
  }
}

export const vaultKeepsService = new VaultKeepsService()