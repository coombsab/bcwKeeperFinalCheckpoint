import { Profile } from "./Profile"

export class Account extends Profile{
  constructor(data) {
    super()
    this.email = data.email
  }
}
