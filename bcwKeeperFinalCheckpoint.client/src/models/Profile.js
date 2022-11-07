export class Profile {
  constructor(data) {
    this.id = data.id || data._id
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.name = data.name
    this.picture = data.picture
    this.bio = data.bio
    this.hobbies = data.hobbies
  }
}