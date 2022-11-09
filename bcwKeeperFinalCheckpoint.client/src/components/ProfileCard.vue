<template>
  <section class="profile-card mt-md-5">
    <div class="pos-relative">
      <img class="cover-img" :src="profile?.coverImg || account?.coverImg" alt="User Cover Image">
      <div class="profile-photo-wrapper">
        <img class="profile-photo elevation-3" :src="profile?.picture || account?.picture"
          :alt="profile?.name || account?.name">
      </div>
    </div>
    <div class="w-100 d-flex justify-content-end px-3">
      <div class="dropdown open" v-if="route.name === 'Account'">
        <button class="btn p-0" type="button" id="profileOptions" data-bs-toggle="dropdown" aria-haspopup="true"
          aria-expanded="false">
          <img src="../assets/img/dots.png" alt="" class="selectable">
        </button>
        <div class="dropdown-menu text-center" aria-labelledby="profileOptions">
          <button class="dropdown-item" data-bs-toggle="modal" data-bs-target="#editProfileModal">Edit</button>
        </div>
      </div>
    </div>
    <div class="pt-10 d-flex flex-column align-items-center">
      <h1>{{ profile?.name || account?.name }}</h1>
      <p v-if="route.name === 'Account'">{{ myVaults?.length }} vaults | {{ myKeeps?.length }} keeps</p>
      <p v-else>{{ vaults?.length }} vaults | {{ keeps?.length }} keeps</p>
      <p>{{ profile?.bio || account?.bio }}</p>
    </div>
  </section>
</template>

<script>
import { computed } from "@vue/reactivity";
import { useRoute } from "vue-router";
import { AppState } from "../AppState";
import { accountService } from "../services/AccountService";
import { Profile } from "../models/Profile";
import Pop from "../utils/Pop";

export default {
  props: {
    profile: { type: Profile },
    account: { type: Object }
  },
  setup(props) {
    const route = useRoute()
    return {
      route,
      myVaults: computed(() => AppState.myVaults),
      myKeeps: computed(() => AppState.myKeeps),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps.filter(keep => !keep.isPrivate)),
    }
  }
}
</script>

<style scoped lang="scss">
.profile-card {
  width: 100vw;
  margin: auto;
}

.pos-relative {
  position: relative;
  height: 70%;
  width: 100%;
}

.cover-img {
  object-position: center;
  size: cover;
  width: 100%;
  height: 100%;
}

.profile-photo-wrapper {
  position: absolute;
  left: 0;
  bottom: -5rem;
  width: 100%;
  display: flex;
  justify-content: center;
}

.profile-photo {
  height: 10rem;
  width: 10rem;
  border-radius: 50%;
}

.pt-10 {
  padding-top: 5rem;
}

@media screen and (min-width: 768px) {
  .profile-card {
    width: 40vw;
  }

  .cover-img {
    border-radius: 6.94872px;

  }
}
</style>