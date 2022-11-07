import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import { api } from "./AxiosService";

class KeepsService {
  async getKeeps()  {
    const res = await api.get("api/keeps")
    AppState.keeps = res.data.map(data => new Keep(data))
  }

  async setActiveKeep(keepId) {
    AppState.activeKeep = null
    const res = await api.get(`api/keeps/${keepId}`)
    let keep = new Keep(res.data)
    AppState.activeKeep = keep
    let keepIndex = AppState.keeps.findIndex(k => k.id === keep.id)
    AppState.keeps.splice(keepIndex, 1, keep)
  }
}

export const keepsService = new KeepsService();