<template>
  <form @submit.prevent="editProfile()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" name="profileName" id="profileName" placeholder="Name" minlength="1" v-model="editable.name" onfocus="select()">
      <label for="profileName">Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" name="profilePicture" id="profilePicture" placeholder="Image URL" v-model="editable.picture" onfocus="select()">
      <label for="profilePicture">Image URL</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" name="profileCoverImg" id="profileCoverImg" placeholder="Cover Image" v-model="editable.coverImg" onfocus="select()">
      <label for="profileCoverImg">Cover Image</label>
    </div>
    <div class="form-floating mb-3">
      <textarea class="form-control" name="profileDescription" id="profileBio"
        placeholder="Bio" v-model="editable.bio" onfocus="select()"></textarea>
      <label for="profileBio">Bio</label>
    </div>
    <div class="text-end">
      <button class="btn btn-dark" type="submit">Edit Profile</button>
    </div>
  </form>
</template>

<script>
import { Modal } from "bootstrap";
import { ref, watchEffect } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState";
import { accountService } from "../services/AccountService";
import Pop from "../utils/Pop";

export default {
  setup() {
    const editable = ref({})
    const route = useRoute()

    watchEffect(() => {
      if (route.name === "Profile") {
        editable.value = {...AppState.activeProfile}
      }
      if (route.name === 'Account') {
        editable.value = {...AppState.account}
      }

    })

    return {
      editable,
      route,
      async editProfile() {
        try {
          await accountService.editProfile(editable.value, route.name)
          Modal.getOrCreateInstance("#editProfileModal").hide()
        }
        catch (error) {
          Pop.error(error.message, "[editProfile]")
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
textarea {
  height: 10.8rem !important;
}
</style>