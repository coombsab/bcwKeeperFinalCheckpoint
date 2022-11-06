import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import { api } from "./AxiosService";

class KeepsService {
  async getKeeps()  {
    console.log("getting the keeps")
    const res = await api.get("api/keeps")
    AppState.keeps = res.data.map(data => new Keep(data))
    console.log(AppState.keeps)
  }
}

export const keepsService = new KeepsService();