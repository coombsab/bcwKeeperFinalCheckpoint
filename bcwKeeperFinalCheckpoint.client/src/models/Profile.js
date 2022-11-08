export class Profile {
  constructor(data) {
    this.id = data.id || data._id
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.name = data.name
    this.picture = data.picture
    this.bio = data.bio
    this.hobbies = data.hobbies
    this.coverImg = data.coverImg || "https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-1-scaled.png"
  }
}