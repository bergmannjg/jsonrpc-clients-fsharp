// generated by ts2fable and interface2record.sh
module rec Hafas

open System

type Promise<'T> =
    abstract _catch: onrejected:option<obj -> 'T> -> Promise<'T>
    abstract _then: onfulfilled:option<'T -> 'TResult> * onrejected:option<obj -> 'TResult> -> Promise<'TResult>

type U1<'a> = Case1 of 'a

type U2<'a, 'b> =
    | Case1 of 'a
    | Case2 of 'b

type U3<'a, 'b, 'c> =
    | Case1 of 'a
    | Case2 of 'b
    | Case3 of 'c


/// A ProductType relates to how a means of transport "works" in local context.
/// Example: Even though S-Bahn and U-Bahn in Berlin are both trains, they have different operators, service patterns,
/// stations and look different. Therefore, they are two distinct products subway and suburban.
type ProductType =
    { id: string
      mode: ProductTypeMode
      name: string
      short: string
      bitmasks: array<int>
      ``default``: bool }
/// A profile is a specific customisation for each endpoint.
/// It parses data from the API differently, add additional information, or enable non-default methods.
type Profile =
    { locale: string
      timezone: string
      endpoint: string
      products: array<ProductType>
      trip: bool option
      radar: bool option
      refreshJourney: bool option
      reachableFrom: bool option
      journeysWalkingSpeed: bool option }
/// A location object is used by other items to indicate their locations.
type Location =
    { ``type``: string
      id: string option
      name: string option
      poi: bool option
      address: string option
      longitude: float option
      latitude: float option
      altitude: float option
      distance: float option }
/// Each public transportation network exposes its products as boolean properties. See {@link ProductType}
type Products = Map<string, bool>
type Facilities = Map<string, string>

type ReisezentrumOpeningHours =
    { Mo: string option
      Di: string option
      Mi: string option
      Do: string option
      Fr: string option
      Sa: string option
      So: string option }
/// A station is a larger building or area that can be identified by a name.
/// It is usually represented by a single node on a public transport map.
/// Whereas a stop usually specifies a location, a station often is a broader area
/// that may span across multiple levels or buildings.
type Station =
    { ``type``: string
      id: string option
      name: string option
      station: U1<Station> option
      location: Location option
      products: Products option
      isMeta: bool option
      /// region ids
      regions: array<string> option
      facilities: Facilities option
      reisezentrumOpeningHours: ReisezentrumOpeningHours option
      stops: array<U3<Station, Stop, Location>> option
      entrances: array<Location> option
      transitAuthority: string option
      distance: float option }
/// Ids of a Stop, i.e. dhid as 'DELFI Haltestellen ID'
type Ids = Map<string, string>
/// A stop is a single small point or structure at which vehicles stop.
/// A stop always belongs to a station. It may for example be a sign, a basic shelter or a railway platform.
type Stop =
    { ``type``: string
      id: string
      name: string option
      station: Station option
      location: Location option
      products: Products option
      lines: array<Line> option
      isMeta: bool option
      reisezentrumOpeningHours: ReisezentrumOpeningHours option
      ids: Ids option
      loadFactor: string option
      entrances: array<Location> option
      transitAuthority: string option
      distance: float option }
/// A region is a group of stations, for example a metropolitan area or a geographical or cultural region.
type Region =
    { ``type``: string
      id: string
      name: string
      /// station ids
      stations: array<string> }

type Line =
    { ``type``: string
      id: string option
      name: string option
      adminCode: string option
      fahrtNr: string option
      additionalName: string option
      product: string option
      ``public``: bool option
      mode: ProductTypeMode option
      /// routes ids
      routes: array<string> option
      operator: Operator option
      express: bool option
      metro: bool option
      night: bool option
      nr: float option
      symbol: string option }
/// A route represents a single set of stations, of a single line.
type Route =
    { ``type``: string
      id: string
      line: string
      mode: ProductTypeMode
      /// stop ids
      stops: array<string> }

type Cycle =
    { min: float option
      max: float option
      nr: float option }

type ArrivalDeparture =
    { arrival: float option
      departure: float option }
/// There are many ways to format schedules of public transport routes.
/// This one tries to balance the amount of data and consumability.
/// It is specifically geared towards urban public transport, with frequent trains and homogenous travels.
type Schedule =
    { ``type``: string
      id: string
      route: string
      mode: ProductTypeMode
      sequence: array<ArrivalDeparture>
      /// array of Unix timestamps
      starts: array<string> }

type Operator =
    { ``type``: string
      id: string
      name: string }

type Hint =
    { ``type``: string
      code: string option
      summary: string option
      text: string
      tripId: string option }

type Geometry =
    { ``type``: string
      coordinates: array<float> }

type Feature =
    { ``type``: string
      properties: U3<Station, Stop, obj> option
      geometry: Geometry }

type FeatureCollection =
    { ``type``: string
      features: array<Feature> }
/// A stopover represents a vehicle stopping at a stop/station at a specific time.
type StopOver =
    { stop: U2<Station, Stop>
      /// null, if last stopOver of trip
      departure: string option
      departureDelay: float option
      prognosedDeparture: string option
      plannedDeparture: string option
      departurePlatform: string option
      prognosedDeparturePlatform: string option
      plannedDeparturePlatform: string option
      /// null, if first stopOver of trip
      arrival: string option
      arrivalDelay: float option
      prognosedArrival: string option
      plannedArrival: string option
      arrivalPlatform: string option
      prognosedArrivalPlatform: string option
      plannedArrivalPlatform: string option
      remarks: array<Hint> option
      passBy: bool option
      cancelled: bool option }
/// Trip – a vehicle stopping at a set of stops at specific times
type Trip =
    { id: string
      origin: U2<Station, Stop>
      destination: U2<Station, Stop>
      departure: string option
      plannedDeparture: string option
      prognosedArrival: string option
      departureDelay: float option
      departurePlatform: string option
      prognosedDeparturePlatform: string option
      plannedDeparturePlatform: string option
      arrival: string option
      plannedArrival: string option
      prognosedDeparture: string option
      arrivalDelay: float option
      arrivalPlatform: string option
      prognosedArrivalPlatform: string option
      plannedArrivalPlatform: string option
      stopovers: array<StopOver> option
      schedule: float option
      price: Price option
      operator: float option
      direction: string option
      line: Line option
      reachable: bool option
      cancelled: bool option
      walking: bool option
      loadFactor: string option
      distance: float option
      ``public``: bool option
      transfer: bool option
      cycle: Cycle option
      alternatives: array<Alternative> option
      polyline: FeatureCollection option
      remarks: array<Hint> option }

type Price =
    { amount: float
      currency: string
      hint: string option }

type Alternative =
    { tripId: string
      direction: string option
      line: Line option
      stop: U2<Station, Stop> option
      ``when``: string option
      plannedWhen: string option
      prognosedWhen: string option
      delay: float option
      platform: string option
      plannedPlatform: string option
      prognosedPlatform: string option
      remarks: array<Hint> option
      cancelled: bool option
      loadFactor: string option
      provenance: string option
      previousStopovers: array<StopOver> option
      nextStopovers: array<StopOver> option }
/// Leg of journey
type Leg =
    { tripId: string option
      origin: U2<Station, Stop>
      destination: U2<Station, Stop>
      departure: string option
      plannedDeparture: string option
      prognosedArrival: string option
      departureDelay: float option
      departurePlatform: string option
      prognosedDeparturePlatform: string option
      plannedDeparturePlatform: string option
      arrival: string option
      plannedArrival: string option
      prognosedDeparture: string option
      arrivalDelay: float option
      arrivalPlatform: string option
      prognosedArrivalPlatform: string option
      plannedArrivalPlatform: string option
      stopovers: array<StopOver> option
      schedule: float option
      price: Price option
      operator: float option
      direction: string option
      line: Line option
      reachable: bool option
      cancelled: bool option
      walking: bool option
      loadFactor: string option
      distance: float option
      ``public``: bool option
      transfer: bool option
      cycle: Cycle option
      alternatives: array<Alternative> option
      polyline: FeatureCollection option
      remarks: array<Hint> option }

type ScheduledDays = Map<string, bool>
/// A journey is a computed set of directions to get from A to B at a specific time.
/// It would typically be the result of a route planning algorithm.
type Journey =
    { ``type``: string
      legs: array<Leg>
      refreshToken: string option
      remarks: array<Hint> option
      price: Price option
      cycle: Cycle option
      scheduledDays: ScheduledDays option }

type Journeys =
    { earlierRef: string option
      laterRef: string option
      journeys: array<Journey> option }

type Duration =
    { duration: float
      stations: array<U3<Station, Stop, Location>> }

type Frame =
    { origin: U2<Stop, Location>
      destination: U2<Stop, Location>
      t: float option }

type Movement =
    { direction: string option
      tripId: string option
      line: Line option
      location: Location option
      nextStopovers: array<StopOver> option
      frames: array<Frame> option
      polyline: FeatureCollection option }

type JourneysOptions =
    {
      /// departure date, undefined corresponds to Date.Now
      departure: DateTime option
      /// arrival date, departure and arrival are mutually exclusive.
      arrival: DateTime option
      /// earlierThan, use {@link Journeys#earlierRef}, earlierThan and departure/arrival are mutually exclusive.
      earlierThan: string option
      /// laterThan, use {@link Journeys#laterRef}, laterThan and departure/arrival are mutually exclusive.
      laterThan: string option
      /// how many search results?
      results: int option
      /// let journeys pass this station
      via: string option
      /// return stations on the way?
      stopovers: bool option
      /// Maximum nr of transfers. Default: Let HAFAS decide.
      transfers: float option
      /// minimum time for a single transfer in minutes
      transferTime: int option
      /// 'none', 'partial' or 'complete'
      accessibility: string option
      /// only bike-friendly journeys
      bike: bool option
      products: Products option
      /// return tickets? only available with some profiles
      tickets: bool option
      /// return a shape for each leg?
      polylines: bool option
      /// parse & expose sub-stops of stations?
      subStops: bool option
      /// parse & expose entrances of stops/stations?
      entrances: bool option
      /// parse & expose hints & warnings?
      remarks: bool option
      /// 'slow', 'normal', 'fast'
      walkingSpeed: string option
      /// start with walking
      startWithWalking: bool option
      /// language to get results in
      language: string option
      /// parse which days each journey is valid on
      scheduledDays: bool option
      ``when``: DateTime option }

type LocationsOptions =
    {
      /// find only exact matches?
      fuzzy: bool option
      /// how many search results?
      results: int option
      /// return stops/stations?
      stops: bool option
      /// return addresses
      addresses: bool option
      /// points of interest
      poi: bool option
      /// parse & expose sub-stops of stations?
      subStops: bool option
      /// parse & expose entrances of stops/stations?
      entrances: bool option
      /// parse & expose lines at each stop/station?
      linesOfStops: bool option
      /// Language of the results
      language: string option }

type TripOptions =
    {
      /// return stations on the way?
      stopovers: bool option
      /// return a shape for the trip?
      polyline: bool option
      /// parse & expose sub-stops of stations?
      subStops: bool option
      /// parse & expose entrances of stops/stations?
      entrances: bool option
      /// parse & expose hints & warnings?
      remarks: bool option
      /// Language of the results
      language: string option }

type StopOptions =
    {
      /// parse & expose lines at the stop/station?
      linesOfStops: bool option
      /// parse & expose sub-stops of stations?
      subStops: bool option
      /// parse & expose entrances of stops/stations?
      entrances: bool option
      /// Language of the results
      language: string option }

type DeparturesArrivalsOptions =
    {
      /// departure date, undefined corresponds to Date.Now
      ``when``: DateTime option
      /// only show departures heading to this station
      direction: string option
      /// show departures for the next n minutes
      duration: float option
      /// max. number of results; `null` means "whatever HAFAS wants"
      results: int option
      /// parse & expose sub-stops of stations?
      subStops: bool option
      /// parse & expose entrances of stops/stations?
      entrances: bool option
      /// parse & expose lines at the stop/station?
      linesOfStops: bool option
      /// parse & expose hints & warnings?
      remarks: bool option
      /// fetch & parse previous/next stopovers?
      stopovers: bool option
      /// departures at related stations
      includeRelatedStations: bool option
      /// language
      language: string option }

type RefreshJourneyOptions =
    {
      /// return stations on the way?
      stopovers: bool option
      /// return a shape for each leg?
      polylines: bool option
      /// return tickets? only available with some profiles
      tickets: bool option
      /// parse & expose sub-stops of stations?
      subStops: bool option
      /// parse & expose entrances of stops/stations?
      entrances: bool option
      /// parse & expose hints & warnings?
      remarks: bool option
      /// language
      language: string option }

type NearByOptions =
    {
      /// maximum number of results
      results: int option
      /// maximum walking distance in meters
      distance: float option
      /// return points of interest?
      poi: bool option
      /// return stops/stations?
      stops: bool option
      /// parse & expose sub-stops of stations?
      subStops: bool option
      /// parse & expose entrances of stops/stations?
      entrances: bool option
      /// parse & expose lines at each stop/station?
      linesOfStops: bool option
      /// language
      language: string option }

type ReachableFromOptions =
    {
      /// when
      ``when``: DateTime option
      /// maximum of transfers
      maxTransfers: float option
      /// maximum travel duration in minutes, pass `null` for infinite
      maxDuration: float option
      /// products
      products: Products option
      /// parse & expose sub-stops of stations?
      subStops: bool option
      /// parse & expose entrances of stops/stations?
      entrances: bool option }

type BoundingBox =
    { north: float
      west: float
      south: float
      east: float }

type RadarOptions =
    {
      /// maximum number of vehicles
      results: int option
      /// nr of frames to compute
      frames: float option
      /// optionally an object of booleans
      products: U2<bool, obj> option
      /// compute frames for the next n seconds
      duration: float option
      /// parse & expose sub-stops of stations?
      subStops: bool option
      /// parse & expose entrances of stops/stations?
      entrances: bool option
      /// return a shape for the trip?
      polylines: bool option
      /// when
      ``when``: DateTime option }

type HafasClient =
    {
      /// Retrieves journeys
      journeys: (U3<string, Station, Location> -> U3<string, Station, Location> -> JourneysOptions option -> Promise<Journeys>)
      /// refreshes a Journey
      refreshJourney: (string -> RefreshJourneyOptions option -> Promise<Journey>) option
      /// Refetch information about a trip
      trip: (string -> string -> TripOptions option -> Promise<Trip>) option
      /// Retrieves departures
      departures: (U2<string, Station> -> DeparturesArrivalsOptions option -> Promise<array<Alternative>>)
      /// Retrieves arrivals
      arrivals: (U2<string, Station> -> DeparturesArrivalsOptions option -> Promise<array<Alternative>>)
      /// Retrieves locations or stops
      locations: (string -> LocationsOptions option -> Promise<array<U3<Station, Stop, Location>>>)
      /// Retrieves information about a stop
      stop: (string -> StopOptions option -> Promise<U3<Station, Stop, Location>>)
      /// Retrieves nearby stops from location
      nearby: (Location -> NearByOptions option -> Promise<array<U3<Station, Stop, Location>>>)
      /// Retrieves stations reachable within a certain time from a location
      reachableFrom: (Location -> ReachableFromOptions option -> Promise<array<Duration>>) option
      /// Retrieves all vehicles currently in an area.
      radar: (BoundingBox -> RadarOptions option -> Promise<array<Movement>>) option }

type ProductTypeMode =
    | Train
    | Bus
    | Watercraft
    | Taxi
    | Gondola
    | Aircraft
    | Car
    | Bicycle
    | Walking
