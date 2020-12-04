<template>
  <div>
    <Nav />
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">
          <ul class="list-group">
            <li class="list-group-item active">
              GAMES
            </li>
            <li v-for="g in storagedGames" :key="g.gameId" class="list-group-item list-game-item">
              <div>
                {{ g.name }}
              </div>
              <select v-model="selectedValues" class="form-control" style="width: 100px; margin: 8px 8px 8px auto">
                <option v-for="friend in friends" :key="friend">{{friend.friendId}}-{{friend.name}}</option>
              </select>
              <button class="btn btn-light" @click="() => handleEmprestar(g)"> Emprestar </button>
            </li>
          </ul>
        </div>
        <div class="col-md-8">
          <div class="row">
            <div v-for="item in storagedGames" :key="item.gameId" class="col-md-4">
              <div class="card" style="margin: 0px 0 32px">
                <div class="card-body">
                  <h5 class="card-title">{{ item.name }}</h5>
                  <p class="card-text">{{ item.type }}</p>
                  <div v-if="(item.friend  != null) && item.isOnLoan == true" class="list-group-item active">
                    <div>
                      {{ item.friend.name }}
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- <button class="btn btn-light" @click="() => listar()"> Listar Atribuições de Emprestimos </button> -->
      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import http from '../utils/http';
import Nav from '@/components/Nav';
import { LOGOUT } from '@/store/actions.type.js';

export default {
  name: 'Dashboard',
  components: {
    Nav,
  },
  data: function() {
    return {
      name: this.$store.state.auth.userName,
      friends: [
        // { Name: 'XX 1', Age: 10, email: 'abc@hotmail.com', Games: [
        //   { Name: "adsdas", type: "action", isOnLoan: true },
        //   { Name: "here", type: "action", isOnLoan: false }
        // ]},
        // { Name: 'YY laksdk', Age: 10, email: 'abc@hotmail.com', Games: [
        //   { Name: "KKK", type: "action", isOnLoan: true },
        //   { Name: "xD", type: "action", isOnLoan: false }
        // ]},
      ],
      storagedGames: [
        // { Name: "assasins creed", type: "action", isOnLoan: false },
        // { Name: "wingin eleven", type: "action", isOnLoan: false },
        // { Name: "um nome muito grande para caber em uma linha", type: "action", isOnLoan: false }
      ],
      selectedValues: {},
      friendsFinal: []
    }
  },
  methods: {
    logout: function() {
      this.$store
        .dispatch(LOGOUT)
        .then(() => {
          this.$router.push({ path: '/' })
        })
        .catch(() => {});
    },
    handleEmprestar: async function(game) {
      if (!game || !this.selectedValues ) {
        return;
      }
      let idFriend = this.selectedValues.split('-');
      console.log(this.selectedValues, game);
      console.log(idFriend[0]);
      let friendObj;
      await http.get(`api/friends/` + idFriend[0] , { headers: { "Authorization":`Bearer ${this.$store.state.auth.token}`} })
      .then((response) => {
        friendObj = response.data;
        console.log("Amigo recuperado: " + friendObj);
      })
      .catch(function () {});

      http.put(`api/game/` + idFriend[0], {
                GameId: game.gameId,
                Name: game.name,
                Type: game.type,
                IsOnLoan: true,
                friend: friendObj 
            },{ headers: { "Authorization":`Bearer ${this.$store.state.auth.token}`} })
      .then(() => {
        console.log("Gravou");
      })
      .catch(function () {console.log("erro");});
    }
  },
  created: function() {
    http.get(`api/friends`, { headers: { "Authorization":`Bearer ${this.$store.state.auth.token}`} })
    .then((response) => {
      this.friends = response.data;
    })
    .catch(function () {});

    http.get(`api/game`, { headers: { "Authorization":`Bearer ${this.$store.state.auth.token}`} })
      .then((responseTwo) => {
        this.storagedGames = responseTwo.data;
      })
    .catch(function () {console.log("erro")});
    
  }
}
</script>


<style>
.list-game-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-direction: row;
}
</style>