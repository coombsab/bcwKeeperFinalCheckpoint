<template>
  <main class="d-flex flex-column">
    <Navbar class="order-md-0 order-1" />
    <div class="order-md-1 order-0">
      <router-view />
    </div>
  </main>
  <KeepDetailsModal />
  <FormModal :title="'Add your keep'" id="createKeepModal">
    <CreateKeepForm />
  </FormModal>
  <FormModal :title="'Add your vault'" id="createVaultModal">
    <CreateVaultForm />
  </FormModal>
  <FormModal :title="'Edit your keep'" id="editKeepModal">
    <EditKeepForm />
  </FormModal>
  <FormModal :title="'Edit your vault'" id="editVaultModal">
    <EditVaultForm />
  </FormModal>
  <FormModal :title="'Edit your profile'" id="editProfileModal">
    <EditProfileForm />
  </FormModal>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import CreateKeepForm from "./components/CreateKeepForm.vue"
import CreateVaultForm from "./components/CreateVaultForm.vue"
import EditKeepForm from "./components/EditKeepForm.vue"
import EditProfileForm from "./components/EditProfileForm.vue"
import EditVaultForm from "./components/EditVaultForm.vue"
import FormModal from "./components/FormModal.vue"
import KeepDetailsModal from "./components/KeepDetailsModal.vue"
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, KeepDetailsModal, FormModal, CreateKeepForm, CreateVaultForm, EditKeepForm, EditVaultForm, EditProfileForm }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}
</style>
