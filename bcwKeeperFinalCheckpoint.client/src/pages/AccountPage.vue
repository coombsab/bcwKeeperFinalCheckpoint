<template>
  <section class="account text-center" v-if="account">
    <ProfileCard :profile="profile" />
    <div class="p-3">
      <h1>Vaults</h1>
    </div>
    <section class="vaults gap-3">
      <VaultCard v-for="v in myVaults" :key="v.id" :vault="v" />
    </section>
    <div class="p-3">
      <h1>Keeps</h1>
    </div>
    <section class="keeps p-3">
      <KeepCard v-for="k in myKeeps" :key="k.id" :keep="k" />
    </section>
  </section>
  <div class="d-flex flex-column h-80 pos-relative" v-else>
    <span class="fadeIn m-auto fs-1 fw-700">Could not find your account.</span>
    <Spinner />
  </div>
</template>

<script>
import { computed, onMounted, watchEffect } from 'vue'
import { AppState } from '../AppState'
import KeepCard from "../components/KeepCard.vue"
import ProfileCard from "../components/ProfileCard.vue"
import VaultCard from "../components/VaultCard.vue"
import { accountService } from "../services/AccountService"
import Pop from "../utils/Pop"
export default {
  setup() {
    async function setActiveProfile() {
      try {
        await accountService.getProfile(AppState.account.id)
      }
      catch(error) {
        Pop.error(error.message, "[setActiveProfile]")
      }
    }

    onMounted(() => {
      setActiveProfile()
    })

    // watchEffect(() => {
    //   if (AppState.user.isAuthenticated) {
    //     setActiveProfile()
    //   }
    // })

    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.activeProfile),
      myVaults: computed(() => AppState.myVaults),
      myKeeps: computed(() => AppState.myKeeps)
    };
  },
  components: { KeepCard, VaultCard, ProfileCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.vaults {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-evenly;
}

.keeps {
  columns: 2;
}

@media screen and (min-width: 768px) {
  .keeps {
    columns: 4;
  }
}
</style>
