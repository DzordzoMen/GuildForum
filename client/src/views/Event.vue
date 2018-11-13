<template>
  <div>
    <b-card
      border-variant="secondary"
      header-border-variant="secondary"
    >
      <b-media>
        <b-row>
          <b-col>
            <h4>
              {{ event.eventName }}
            </h4>
          </b-col>
          <b-col offset-md="4">
            <b-col id="user">
              {{ event.nick }}
            </b-col>
            <b-col>
              <small class="text-muted">
                {{ event.groupName }}
              </small>
            </b-col>
          </b-col>
        </b-row>

        <b-col>
          {{ event.eventDescription }}
        </b-col>

        <br>

        <b-row>
          <b-col>
            <small class="text-muted">
              {{ event.eventDate }}
            </small>
          </b-col>
        </b-row>

      </b-media>
    </b-card>

    <ul class="eventMembers-area">
      <b-media v-for="eventMember in event.eventMembers" v-bind:key="eventMember.userID" tag="li">
        <b-img rounded slot="aside" blank blank-color="#abc" width="64" alt="placeholder" />

        <b-row>
          <b-col cols="1">
            <h4 class="mt-0 mb-1" @click="showUser(eventMember.userID)" id="user">
              {{ eventMember.nick }}
            </h4>
          </b-col>
          <b-col offset-md="9">
            <b-col :style="setStatusColor(eventMember.standby)">
              {{ eventMember.standby }}
            </b-col>
            <b-col v-if="eventMember.standby === 'Oczekiwanie'">
              <b-button
                size="sm"
                variant="success"
                v-b-tooltip.html.bottom
                title="Zaakceptuj"
                @click="updateStatus(eventMember.userID, 'Zaakceptowano')"
              >
                o/
              </b-button>
              <b-button
                size="sm"
                variant="warning"
                v-b-tooltip.html.bottom
                title="Lista rezerwowa"
                style="margin-left:5px;"
                @click="updateStatus(eventMember.userID, 'Rezerwa')"
              >
                ^
              </b-button>
              <b-button
                size="sm"
                variant="danger"
                v-b-tooltip.html.bottom
                title="Odrzuć"
                style="margin-left:5px;"
                @click="rejectMember(eventMember.userID)"  
              >
                x
              </b-button>
            </b-col>
          </b-col>
        </b-row>

        <b-row>
          <b-col>
            <small class="text-muted">
              Grupa: 
            </small>
            {{ eventMember.groupName }}
          </b-col>
        </b-row>

      </b-media>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'event',
  data() {
    return {
      event: {},
    };
  },
  created() {
    // send cookie
    const id = this.$route.params.eventId;
    this.$http.get(`/api/event/${id}/members`)
      .then((response) => {
        this.event = response.body;
      });
  },
  methods: {
    setStatusColor(name) {
      switch (name) {
        case 'Zaakceptowano':
          return {'color':'#177B14'};

        case 'Oczekiwanie':
          return {'color':'#EC6E2F'}

        case 'Rezerwa':
          return {'color':'#E39621'}

        case 'Odrzucono':
          return {'color':'#DE3933'};

        default:
          return {'color':'#322020'};
      }
    },
    rejectMember(idMember) {
      const id = this.event.eventID;
      this.$http.delete(`/api/event/${id}/members/${idMember}`)
        .then(() => {
          // TODO CHANGE STANDBY
      });
    },
    updateStatus(idMember, status) {
      const id = this.event.eventID;
      this.$http.put(`/api/event/${id}/members/${idMember}`, {
        standby: status,
      }).then(() => {
          // TODO CHANGE STANDBY
      });
    }
  },
};
</script>

<style lang="scss">
  .eventMembers-area {
    & > li {
      margin-top: 25px;
    }
  }

  #user:hover {
    cursor: pointer;
    color:#88f;
    // blueviolet
  }
</style>
